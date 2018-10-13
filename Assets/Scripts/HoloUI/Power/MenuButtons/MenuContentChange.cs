using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuContentChange : MonoBehaviour {

    public GameObject eventManager;
    public GameObject runContent;
    public GameObject theFirstVictim;
    public GameObject theSecondVictim;
    public GameObject theThirdVictim;


    private HoloGuideInput manipulateHand;
    private Config powerSetting;


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();

            if (manipulateHand.airTap == true)
            {
                    runContent.SetActive(true);
                    theFirstVictim.SetActive(false);
                    theSecondVictim.SetActive(false);
                    theThirdVictim.SetActive(false);
                    manipulateHand.airTap = false;

            }

        }

    }


}