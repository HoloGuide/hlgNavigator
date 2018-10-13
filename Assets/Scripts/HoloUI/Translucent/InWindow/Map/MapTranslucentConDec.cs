using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapTranslucentConDec : MonoBehaviour {

    public float mapTranslucent;
    public Vector3 canEnterPosition;
    public GameObject eventManager;
    public GameObject changeText;
    public GameObject mapBase;
    public GameObject mapContent;
    public GameObject scaleConBase;
    public GameObject scaleUpButton;
    public GameObject scaleDownButton;

    private Config translucentSetting;
    private MapTranslucentConTextChange textCon;
    private HoloGuideInput manipulateHand;


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();

            if (manipulateHand.airTap == true)
            {
                textCon = changeText.GetComponent<MapTranslucentConTextChange>();
                translucentSetting = eventManager.GetComponent<Config>();

                if (translucentSetting.mapTranslucent > 0)
                {
                    translucentSetting.mapTranslucent--;

                }

                mapTranslucent = (float)translucentSetting.mapTranslucent;

                mapContent.GetComponent<Image>().color = new Color(1f, 1f, 1f, mapTranslucent / 100f);
                mapBase.GetComponent<Image>().color = new Color(1f, 1f, 1f, mapTranslucent / 100f);
                scaleConBase.GetComponent<Image>().color = new Color(1f, 1f, 1f, mapTranslucent / 100f);
                scaleUpButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, mapTranslucent / 100f);
                scaleDownButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, mapTranslucent / 100f);

                textCon.TextUpdate();
                manipulateHand.airTap = false;

            }

            if (manipulateHand.drag)
            {
                textCon = changeText.GetComponent<MapTranslucentConTextChange>();
                translucentSetting = eventManager.GetComponent<Config>();

                if (translucentSetting.mapTranslucent > 0)
                {
                    translucentSetting.mapTranslucent--;

                }

                mapTranslucent = (float)translucentSetting.mapTranslucent;

                mapContent.GetComponent<Image>().color = new Color(1f, 1f, 1f, mapTranslucent / 100f);
                mapBase.GetComponent<Image>().color = new Color(1f, 1f, 1f, mapTranslucent / 100f);
                scaleConBase.GetComponent<Image>().color = new Color(1f, 1f, 1f, mapTranslucent / 100f);
                scaleUpButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, mapTranslucent / 100f);
                scaleDownButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, mapTranslucent / 100f);
                textCon.TextUpdate();

            }

        }

    }


}
