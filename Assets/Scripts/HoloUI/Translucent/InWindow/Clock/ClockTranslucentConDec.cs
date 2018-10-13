using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockTranslucentConDec : MonoBehaviour {

    public float clockTranslucent;

    public GameObject eventManager;
    public GameObject changeText;

    public GameObject clockBackGroundImage;

    private Config translucentSetting;
    private ClockTranslucentConTextChange textCon;
    private HoloGuideInput manipulateHand;


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();

            if (manipulateHand.airTap == true)
            {
                textCon = changeText.GetComponent<ClockTranslucentConTextChange>();
                translucentSetting = eventManager.GetComponent<Config>();

                if (translucentSetting.clockTranslucent > 0)
                {
                    translucentSetting.clockTranslucent--;

                }

                clockTranslucent = (float)translucentSetting.clockTranslucent;

                clockBackGroundImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, clockTranslucent / 100f);
                
                textCon.TextUpdate();
                manipulateHand.airTap = false;

            }

            if (manipulateHand.drag)
            {
                textCon = changeText.GetComponent<ClockTranslucentConTextChange>();
                translucentSetting = eventManager.GetComponent<Config>();

                if (translucentSetting.clockTranslucent > 0)
                {
                    translucentSetting.clockTranslucent--;

                }

                clockTranslucent = (float)translucentSetting.clockTranslucent;

                clockBackGroundImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, clockTranslucent / 100f);

                textCon.TextUpdate();

            }

        }

    }


}