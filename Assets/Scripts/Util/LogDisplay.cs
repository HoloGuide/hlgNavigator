using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LogDisplay : MonoBehaviour
{
    public List<Text> Labels = new List<Text>();
    public int MaxLine = 15;
    public int MaxCh = 50;

    private List<string> logQueue = new List<string>();
    private string Log = "";

    private void Awake()
    {
        Application.logMessageReceivedThreaded += HandleLog;
    }

    private void OnDestroy()
    {
        Application.logMessageReceivedThreaded -= HandleLog;
    }

    private void Update()
    {
        if (Labels.Count == 0) return;
        if (logQueue.Count == 0) return;

        foreach (var log in logQueue)
        {
            var _log = log.Substring(0, Math.Min(MaxCh, log.Length));
            Log = _log + Environment.NewLine + Log;
            var lines = Log.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            if (lines.Count() > MaxLine)
            {
                Log = string.Join(Environment.NewLine, lines.Where(x => x != lines.Last()));
            }
        }
        logQueue.Clear();

        foreach (var label in Labels)
        {
            if (label == null) continue;
            if (!label.gameObject.activeInHierarchy)
            {
                label.gameObject.SetActive(true);
            }

            label.text = Log;
        }
    }

    private void HandleLog(string logText, string stackTrace, LogType type)
    {
        logQueue.Add(logText);
    }
}