using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouteTranslucentConInc : MonoBehaviour
{

    public float routeTranslucent;

    public GameObject eventManager;
    public GameObject changeText;

    public GameObject point1;
    public GameObject line1;
    public GameObject square1;
    public GameObject point2;
    public GameObject line2;
    public GameObject square2;
    public GameObject jointLine1;
    public GameObject jointLine2;
    public GameObject circle;

    private Config translucentSetting;
    private RouteTranslucentConTextChange textCon;
    private HoloGuideInput manipulateHand;


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();

            if (manipulateHand.airTap == true)
            {
                textCon = changeText.GetComponent<RouteTranslucentConTextChange>();
                translucentSetting = eventManager.GetComponent<Config>();

                if (translucentSetting.routeTranslucent < 100)
                {
                    translucentSetting.routeTranslucent++;

                }

                routeTranslucent = (float)translucentSetting.routeTranslucent;

                point1.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                line1.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                square1.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                point2.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                line2.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                square2.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                jointLine1.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                jointLine2.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);

                textCon.TextUpdate();
                manipulateHand.airTap = false;

            }

            if (manipulateHand.drag)
            {
                textCon = changeText.GetComponent<RouteTranslucentConTextChange>();
                translucentSetting = eventManager.GetComponent<Config>();

                if (translucentSetting.routeTranslucent < 100)
                {
                    translucentSetting.routeTranslucent++;

                }

                routeTranslucent = (float)translucentSetting.routeTranslucent;

                point1.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                line1.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                square1.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                point2.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                line2.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                square2.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                jointLine1.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                jointLine2.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);
                circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, routeTranslucent / 100f);

                textCon.TextUpdate();

            }

        }

    }


}

