using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LogDisplay : MonoBehaviour
{
    public Text Label = null;
    public bool MultiLine = false;
    public int MaxLine = 15;

    private void Awake()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDestroy()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void Update()
    {
        if (!Label.gameObject.activeInHierarchy && WebSocketManager.IsInitialized && WebSocketManager.Instance.IsDebug)
        {
            Label.gameObject.SetActive(true);
        }
    }

    private void HandleLog(string logText, string stackTrace, LogType type)
    {
        if (!Label.gameObject.activeInHierarchy) return;

        if (Label.text != "" && MultiLine)
        {
            string text = Label.text;

            text += Environment.NewLine + logText;

            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            if (lines.Count() > MaxLine)
            {
                text = string.Join(Environment.NewLine, lines.Skip(1));
            }

            Label.text = text;
        }
        else
        {
            Label.text = logText;
        }

    }
}