using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.XR.WSA;
using UnityEngine.XR.WSA.Input;
using UnityEngine.XR.WSA.Persistence;

using HoloToolkit.Unity.InputModule;

/// <summary>
/// WorldAnchorを用いて現実空間に3Dオブジェクト(Map)を配置する
/// </summary>
public class LocateMap : MonoBehaviour
{
    public string AnchorID;

    private GestureRecognizer m_gr;
    private WorldAnchorStore m_anchorStore;
    private GazeManager m_gazeManager;

    private AnchorSaveManager m_anchorSaveManager;

    public void Locate()
    {
        m_gazeManager = GazeManager.Instance;

        // Tapの検出 (Global)
        m_gr = new GestureRecognizer();
        m_gr.Tapped += OnTapped;
        m_gr.StartCapturingGestures();

        // WorldAnchorを取得する
        WorldAnchorStore.GetAsync(AnchorStoreReady);
    }

    // WorldAnchorStoreのロード完了 (onCompleted)
    private void AnchorStoreReady(WorldAnchorStore store)
    {
        m_anchorStore = store;

        m_anchorSaveManager = new AnchorSaveManager(m_anchorStore, gameObject);
        m_anchorSaveManager.FileName = AnchorID;

        bool loaded = false;
        string[] ids = m_anchorStore.GetAllIds();
        foreach (var id in ids)
        {
            if (id == AnchorID)
            {
                m_anchorStore.Load(id, gameObject);
                Debug.Log("--- Anchor Loaded. ---");

                // Mapを表示
                gameObject.transform.GetChild(0).gameObject.SetActive(true);

                loaded = true;
                break;
            }
        }

        if (!loaded)
        {
            // AnchorStoreになければファイルからロード
            m_anchorSaveManager.ImportAnchor();
        }

    }
    
    private void OnTapped(TappedEventArgs args)
    {
        // MapがActiveでない(WorldAnchorが取得できていない) or 回帰直線が取得できていなければ終了
        if (!gameObject.transform.GetChild(0).gameObject.activeInHierarchy) return;
        if (!AVGLine.IsInitialized) return;

        // 回帰直線の始点・終点を取得し、その方向ベクトルにMapの壁を揃える

        List<Vector3> v3 = AVGLine.Instance.LineVects;
        Vector3 dir = (v3.Last() - v3.First()).normalized;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

        Debug.Log("--- Model fitted. ---");

        // 目線の高さに揃えるために、真下にRayを打ち、壁のモデルの高さを揃える
        transform.position = m_gazeManager.HitInfo.point;
        RaycastHit rh;
        if (Physics.Raycast(m_gazeManager.GazeOrigin, Vector3.down, out rh, 100))
        {
            transform.position = new Vector3(
                transform.position.x,
                rh.point.y,
                transform.position.z
            );
        }

        // WorldAnchor再登録のために事前に削除
        DeleteAnchor();

        // WorldAnchorStoreから正常に削除できたら、
        // WorldAnchorを再度WorldAnchorStoreに保存
        var anchor = gameObject.AddComponent<WorldAnchor>();
        if (anchor.isLocated)
        {
            m_anchorStore.Save(AnchorID, anchor);
        }
        else
        {
            anchor.OnTrackingChanged += OnTrackingChanged;
        }

    }

    public void DeleteAnchor()
    {
        // WorldAnchor再登録のために事前に削除
        var worldAnchor = this.GetComponent<WorldAnchor>();

        if (worldAnchor != null)
        {
            Destroy(worldAnchor);
        }

        if (m_anchorStore != null && m_anchorStore.GetAllIds().Contains(AnchorID))
        {
            if (m_anchorStore.Delete(AnchorID))
            {
                Debug.Log("Deleting anchor success!");
            }
            else
            {
                Debug.Log("Failed to delete anchor.");
            }
        }
    }

    public void Reload()
    {
        if (m_anchorSaveManager != null)
        {
            m_anchorSaveManager.ReloadAnchor();
        }
    }

    private void OnTrackingChanged(WorldAnchor self, bool located)
    {
        if (located)
        {
            m_anchorStore.Save(AnchorID, self);
            self.OnTrackingChanged -= OnTrackingChanged;
        }
    }

}
