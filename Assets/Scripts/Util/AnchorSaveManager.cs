using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using UnityEngine.XR.WSA;
using UnityEngine.XR.WSA.Persistence;
using UnityEngine.XR.WSA.Sharing;

#if !UNITY_EDITOR && UNITY_WSA
using Windows.Storage;
#endif

using static OpenFileHelper;

public class AnchorSaveManager
{
    public AnchorSaveManager(WorldAnchorStore anchorStore, GameObject gameObject)
    {
        m_anchorStore = anchorStore;
        m_gameObject = gameObject;

        exportingAnchorBytes = new List<byte>();
    }

    /// <summary>
    /// WorldAnchor保存時のファイル名
    /// </summary>
    public string FileName;

    /// <summary>
    /// ファイル拡張子
    /// </summary>
    private const string fileExtension = ".anchor";

    /// <summary>
    /// ファイル保存先 (デバイス依存)
    /// </summary>
    private string SavePath
    {
        get
        {
#if !UNITY_EDITOR && UNITY_WSA
            return ApplicationData.Current.RoamingFolder.Path;
#else
            return Application.persistentDataPath;
#endif
        }
    }

    /// <summary>
    /// WorldAnchorをAttachしたいGameObject
    /// </summary>
    private GameObject m_gameObject;

    private WorldAnchorStore m_anchorStore;

    private WorldAnchorTransferBatch sharedAnchorInterface;

    /// <summary>
    /// ImportされたAnchorのID
    /// </summary>
    private string m_importedAnchorID = null;

    /// <summary>
    /// Export時のAnchor名 (UUID)
    /// </summary>
    private string m_exportingAnchorID;    

    /// <summary>
    /// Export用バッファ
    /// </summary>
    private List<byte> exportingAnchorBytes;

    /// <summary>
    /// ストレージからWorldAnchorを読み込みデシリアライズします。
    /// </summary>
    public void ImportAnchor()
    {
        Debug.Log("Importing...");

        try
        {
            List<byte> data = new List<byte>();

            using (Stream stream = OpenFileForRead(SavePath, FileName + fileExtension))
            {
                byte[] _data = new byte[stream.Length];
                stream.Read(_data, 0, (int)stream.Length);
                data.AddRange(_data);
            }

            Debug.Log("Data loaded.");
            WorldAnchorTransferBatch.ImportAsync(data.ToArray(), ImportComplete);
            Debug.Log("Waiting to import...");
        }
        catch (Exception)
        {
            Debug.Log("Data load errored.");
        }
    }

    /// <summary>
    /// WorldAnchorのデシリアライズ完了 (onCompleted)
    /// </summary>
    private void ImportComplete(SerializationCompletionReason status, WorldAnchorTransferBatch anchorBatch)
    {
        Debug.Log("Import Complete.");

        if (status == SerializationCompletionReason.Succeeded)
        {
            if (anchorBatch.GetAllIds().Length > 0)
            {
                // デシリアライズしたアンカーの名前を取得
                string first = anchorBatch.GetAllIds()[0];
                m_importedAnchorID = first;
                Debug.Log("Anchor Manager: Sucessfully imported anchor " + first);

                // アンカーをGameObjectに取り付け現実空間に固定し、ローカルのストアに保存する
                WorldAnchor anchor = anchorBatch.LockObject(first, m_gameObject);
                m_anchorStore.Save(first, anchor);
            }
        }
        else
        {
            Debug.LogError("Anchor Manager: Import failed");
        }
    }

    /// <summary>
    /// ImportしたWorldAnchorによってGameObjectを現実空間に固定し直します。
    /// </summary>
    public void ReloadAnchor()
    {
        m_anchorStore.Load(m_importedAnchorID, m_gameObject);
    }

    /// <summary>
    /// WorldAnchorをシリアライズしてストレージに保存します。
    /// </summary>
    public void ExportAnchor()
    {
        string guidString = Guid.NewGuid().ToString();
        m_exportingAnchorID = guidString;

        // ローカルのストアにアンカーを保存
        var worldAnchor = m_gameObject.GetComponent<WorldAnchor>();
        if (worldAnchor != null && m_anchorStore.Save(m_exportingAnchorID, worldAnchor))
        {
            // 保存成功時
            Debug.Log("Anchor Manager: Exporting anchor " + m_exportingAnchorID);

            // WorldAnchorTransferBatchにアンカーのシリアライズを委譲
            sharedAnchorInterface = new WorldAnchorTransferBatch();
            sharedAnchorInterface.AddWorldAnchor(guidString, worldAnchor);

            WorldAnchorTransferBatch.ExportAsync(sharedAnchorInterface, WriteBuffer, ExportComplete);
        }
        else
        {
            Debug.LogWarning("Anchor Manager: Failed to export anchor, trying again...");
        }
    }

    // 
    /// <summary>
    /// シリアライズしたデータをリストに配置する(onDataAvailable)
    /// </summary>
    private void WriteBuffer(byte[] data)
    {
        exportingAnchorBytes.AddRange(data);
    }

    /// <summary>
    /// WorldAnchorのシリアライズ完了 (onCompleted)
    /// </summary>
    private void ExportComplete(SerializationCompletionReason status)
    {
        if (status == SerializationCompletionReason.Succeeded)
        {
            var data = exportingAnchorBytes.ToArray();
            using (Stream stream = OpenFileForWrite(SavePath, FileName + fileExtension))
            {
                stream.Write(data, 0, data.Length);
                stream.Flush();
            }

            Debug.Log("Anchor Manager: Exported anchor: " + m_exportingAnchorID);
        }
        else
        {
            Debug.LogWarning("Anchor Manager: Failed to upload anchor, trying again...");
        }
    }

}
