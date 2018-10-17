using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using HoloToolkit.Unity.InputModule;
using System;

public class NavigationController : MonoBehaviour, IInputClickHandler
{
    public GameObject SceneContent;

    public GameObject AddressDialog;
    public InputField AddressInputField;
    public Text Title;

    public GameObject Navigator;
    public GameObject SpatialMapping;
    public GameObject RegressionLine;

    public GameObject ErrorScreen;

    private Queue<Action> actionDoMainThreads = new Queue<Action>();

    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
    }

    private void Update()
    {
        while (actionDoMainThreads.Count > 0)
        {
            var action = actionDoMainThreads.Dequeue();

            action?.Invoke();
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
        actionDoMainThreads.Enqueue(() =>
        {
            _OnConnected();
        });
    }

    public void OnRouteChanged()
    {
        actionDoMainThreads.Enqueue(() =>
        {
            _OnRouteChanged();
        });
    }

    public void OnDisconnected()
    {
        actionDoMainThreads.Enqueue(() =>
        {
            _OnDisconnected();
        });
    }

    private void _OnConnected()
    {
        Title.text = "Android待機中...";
    }

    private void _OnRouteChanged()
    {
        Debug.Log("_OnRouteChanged 0");
        SceneContent.transform.Find("WebSocket").gameObject.SetActive(false);
        Debug.Log("_OnRouteChanged 1");

        SpatialMapping.SetActive(true);
        Debug.Log("_OnRouteChanged 2");

        RegressionLine.GetComponent<LineRenderer>().gameObject.SetActive(true);
        Debug.Log("_OnRouteChanged 3");
        // Navigator.SetActive(true);

        SceneContent.transform.Find("Navigation").gameObject.SetActive(true);
        Debug.Log("_OnRouteChanged 4");
    }

    private void _OnDisconnected()
    {
        SceneContent.transform.Find("Navigation").gameObject.SetActive(false);
        // Navigator.SetActive(false);

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
