﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using WebSocketSharp;
using HoloToolkit.Unity;

#if !UNITY_EDITOR && UNITY_WSA
using Windows.Networking;
using Windows.Networking.Connectivity;
#endif

public class WebSocketManager : Singleton<WebSocketManager>
{
    public NavigationController navigationController;
    public string DebugAddress = "";
    public bool Retry = false;

    public string URI { get; private set; }

    private const float RECONNECT_INTERVAL = 10.0f; // s
    private static bool Connected = false;

    private Action actionDoMainThread = null;

    private WebSocket _ws;

    private void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            if (string.IsNullOrEmpty(DebugAddress))
            {
                var my_ip_separated = GetIPAddress().Split('.');

                var ip_dst = string.Join(".", my_ip_separated.Take(3)) + ".1";

                URI = "ws://" + ip_dst + ":8080/ws";
            } else
            {
                URI = "ws://" + DebugAddress + ":8080/ws";
            }

            Debug.Log(URI);

            Connect();
        }
    }

    private void Update()
    {
        if (actionDoMainThread != null)
        {
            actionDoMainThread.Invoke();
            actionDoMainThread = null;
        }
    }

    public void Connect(string uri)
    {
        URI = uri;
        Connect();
    }

    public void Close()
    {
        _ws.Close();
    }

    private void Connect()
    {
        _ws = new WebSocket(URI);

        // 文字列受信
        _ws.OnMessage += (s, e) =>
        {
            // Debug.Log(e.Data);
            JsonParser.Instance.ParseJson(e.Data);
        };

        // サーバー接続完了
        _ws.OnOpen += (s, e) =>
        {
            Debug.Log("Connected.");
            Connected = true;
            navigationController.OnConnected();
        };

        // 接続断の発生
        _ws.OnError += (s, e) =>
        {
            Debug.Log("Errored.");

            if (Retry)
            {
                Debug.Log("Reconnecting...");
                actionDoMainThread = () =>
                {
                    Invoke("Connect", RECONNECT_INTERVAL);
                };
            }
        };

        // 接続断の発生
        _ws.OnClose += (s, e) =>
        {
            Debug.Log("Closed.");

            if (Connected)
            {
                navigationController.OnDisconnected();
            }
            else if (Retry)
            {
                Debug.Log("Reconnecting...");
                Invoke("Connect", RECONNECT_INTERVAL);
            }
        };
        
        // サーバー接続開始
        _ws.ConnectAsync();
    }

    public static string GetIPAddress()
    {

#if !UNITY_EDITOR && UNITY_WSA
        string ip = null;
        foreach (HostName localHostName in NetworkInformation.GetHostNames())
        {
            if (localHostName.IPInformation != null)
            {
                if (localHostName.Type == HostNameType.Ipv4)
                {
                    ip = localHostName.ToString();
                    break;
                }
            }
        }
        return ip;
#else
        return Network.player.ipAddress;
#endif
    }

}
