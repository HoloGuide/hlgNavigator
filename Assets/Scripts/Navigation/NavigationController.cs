using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using HoloToolkit.Unity.InputModule;

public class NavigationController : MonoBehaviour, IInputClickHandler
{
    public GameObject SceneContent;

    public GameObject AddressDialog;
    public InputField AddressInputField;

    public GameObject Navigator;
    public GameObject SpatialMapping;
    public GameObject RegressionLine;

    public GameObject ErrorScreen;

    private bool onConnected = false;
    private bool onDisconnected = false;

    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
    }

    private void LateUpdate()
    {
        if (onConnected)
        {
            _OnConnected();
            onConnected = false;
        }

        if (onDisconnected)
        {
            _OnDisconnected();
            onDisconnected = false;
        }
    }

    public void BtnConnect_OnClick()
    {
        var ip = AddressInputField.text;
        var uri = "ws://" + ip + ":8080/ws";

        WebSocketManager.Instance.Connect(uri);
    }

    public void OnConnected()
    {
        onConnected = true;
    }

    public void OnDisconnected()
    {
        onDisconnected = true;
    }

    private void _OnConnected()
    {
        SceneContent.transform.Find("WebSocket").gameObject.SetActive(false);

        SpatialMapping.SetActive(true);

        RegressionLine.GetComponent<LineRenderer>().gameObject.SetActive(true);
        Navigator.SetActive(true);

        SceneContent.transform.Find("Navigation").gameObject.SetActive(true);
    }

    private void _OnDisconnected()
    {
        SceneContent.transform.Find("Navigation").gameObject.SetActive(false);
        Navigator.SetActive(false);

        RegressionLine.GetComponent<LineRenderer>().gameObject.SetActive(false);
        SpatialMapping.SetActive(false);

        ErrorScreen.SetActive(true);
        var tran = ErrorScreen.transform;
        tran.Find("Caption").GetComponent<Text>().text = "エラー";
        tran.Find("Content").GetComponent<Text>().text = "Androidから切断されました。\r\nアプリを終了してください。";
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Tapped");
        if (!AddressDialog.activeInHierarchy)
        {
            SceneContent.GetComponent<BodyLocked>().enabled = false;
            AddressDialog.SetActive(true);
            InputManager.Instance.RemoveGlobalListener(gameObject);
        }
    }
    
}
