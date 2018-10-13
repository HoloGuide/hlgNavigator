using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeTranslucentConInc : MonoBehaviour
{

    public float noticeTranslucent;

    public GameObject eventManager;
    public GameObject changeText;

    public GameObject noticeBackGroundImage;

    private Config translucentSetting;
    private NoticeTranslucentConTextChange textCon;
    private HoloGuideInput manipulateHand;


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();

            if (manipulateHand.airTap == true)
            {
                textCon = changeText.GetComponent<NoticeTranslucentConTextChange>();
                translucentSetting = eventManager.GetComponent<Config>();

                if (translucentSetting.noticeTranslucent < 100)
                {
                    translucentSetting.noticeTranslucent++;

                }

                noticeTranslucent = (float)translucentSetting.noticeTranslucent;

                noticeBackGroundImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, noticeTranslucent / 100f);

                textCon.TextUpdate();
                manipulateHand.airTap = false;

            }

            if (manipulateHand.drag)
            {
                textCon = changeText.GetComponent<NoticeTranslucentConTextChange>();
                translucentSetting = eventManager.GetComponent<Config>();

                if (translucentSetting.noticeTranslucent < 100)
                {
                    translucentSetting.noticeTranslucent++;

                }

                noticeTranslucent = (float)translucentSetting.noticeTranslucent;

                noticeBackGroundImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, noticeTranslucent / 100f);

                textCon.TextUpdate();

            }

        }

    }


}