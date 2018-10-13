using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRoutePower : MonoBehaviour {

    public GameObject eventManager;

    private HoloGuideInput manipulateHand;
    private Config powerSetting;


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();

            if (manipulateHand.airTap == true)
            {
                powerSetting = eventManager.GetComponent<Config>();

                if (powerSetting.routePower == true)
                {
                    powerSetting.routePower = false;
                    manipulateHand.airTap = false;

                }
                else if (powerSetting.routePower == false)
                {
                    powerSetting.routePower = true;
                    manipulateHand.airTap = false;

                }

            }

        }

    }


}
