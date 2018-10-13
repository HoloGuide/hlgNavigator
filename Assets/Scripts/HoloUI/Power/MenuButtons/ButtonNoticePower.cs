using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNoticePower : MonoBehaviour {

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

                if (powerSetting.noticePower == true)
                {
                    powerSetting.noticePower = false;
                    manipulateHand.airTap = false;

                }
                else if (powerSetting.noticePower == false)
                {
                    powerSetting.noticePower = true;
                    manipulateHand.airTap = false;

                }

            }

        }

    }


}
