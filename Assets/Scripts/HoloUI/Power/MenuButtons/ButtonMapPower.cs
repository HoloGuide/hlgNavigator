using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMapPower : MonoBehaviour {

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

                if (powerSetting.mapPower == true)
                {
                    powerSetting.mapPower = false;
                    manipulateHand.airTap = false;

                }
                else if (powerSetting.mapPower == false)
                {
                    powerSetting.mapPower = true;
                    manipulateHand.airTap = false;

                }

            }

        }

    }


}