﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockTranslucentConTextChange : MonoBehaviour {

    public GameObject eventManager;
    private Text targetText;

    private Config translucentSetting;

    public void Start()
    {
        translucentSetting = eventManager.GetComponent<Config>();
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = translucentSetting.clockTranslucent + "%";

    }


    public void TextUpdate()
    {
        translucentSetting = eventManager.GetComponent<Config>();
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = translucentSetting.clockTranslucent + "%";

    }
}
