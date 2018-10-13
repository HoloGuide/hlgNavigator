using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangeButtonBig : MonoBehaviour
{

    public GameObject eventManager;
    public GameObject mapContent;
    public GameObject mapEffect;
    public GameObject routeContent;
    public GameObject routeEffect;
    public GameObject clockContent;
    public GameObject clockEffect;

    public GameObject window;
    public GameObject target;

    private HoloGuideInput manipulateHand;
    private Config setting;


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();

            if (manipulateHand.airTap == true)
            {
                setting = eventManager.GetComponent<Config>();

                if (setting.mapScale != 2 && setting.sizeConTargetObject == 1)
                {
                    setting.mapScale = 2;
                    mapContent.transform.localScale = new Vector3(1.3f, 1.3f, 1.0f);
                    mapEffect.transform.localScale = new Vector3(1.3f, 1.3f, 1.0f);
                    target.transform.localPosition = new Vector3(150, 30, 0);
                    manipulateHand.airTap = false;
                    window.SetActive(false);

                }

                if (setting.routeScale != 2 && setting.sizeConTargetObject == 2)
                {
                    setting.routeScale = 2;
                    routeContent.transform.localScale = new Vector3(1.3f, 1.3f, 1.0f);
                    routeEffect.transform.localScale = new Vector3(1.3f, 1.3f, 1.0f);
                    target.transform.localPosition = new Vector3(150, 30, 0);
                    manipulateHand.airTap = false;
                    window.SetActive(false);

                }

                if (setting.clockScale != 2 && setting.sizeConTargetObject == 3)
                {
                    setting.clockScale = 2;
                    clockContent.transform.localScale = new Vector3(1.3f, 1.3f, 1.0f);
                    clockEffect.transform.localScale = new Vector3(1.3f, 1.3f, 1.0f);
                    target.transform.localPosition = new Vector3(150, 30, 0);
                    manipulateHand.airTap = false;
                    window.SetActive(false);

                }

            }

        }

    }


}

