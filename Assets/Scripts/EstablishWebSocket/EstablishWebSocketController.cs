using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;

public class EstablishWebSocketController : MonoBehaviour, IInputClickHandler
{
    public GameObject SceneContent;
    public GameObject AddressDialog;
    public InputField AddressInputField;

    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
    }

    public void BtnConnect_OnClick()
    {
        WebSocketManager.Instance.IsDebug = true;

        var ip = AddressInputField.text;
        var uri = "ws://" + ip + ":8080/ws";

        WebSocketManager.Instance.Connect(uri);
    }

    public void BtnNext_OnClick()
    {
        WebSocketManager.Instance.IsDebug = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Navigation");
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
