using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockBehaviour : MonoBehaviour
{
    private Text ClockLabel;
    private float timeLeft;

    private bool colonVisible = false;

    private void Start()
    {
        ClockLabel = this.GetComponent<Text>();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0.0)
        {
            return;
        }

        timeLeft = 0.5f;

        colonVisible = !colonVisible;

        var now = DateTime.Now;
        ClockLabel.text = now.Hour.ToString("D2") + (colonVisible ? ":" : " ") + now.Minute.ToString("D2");

    }

}
