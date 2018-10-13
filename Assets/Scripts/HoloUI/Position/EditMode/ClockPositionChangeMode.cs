using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPositionChangeMode : MonoBehaviour
{

    public GameObject clockContent;
    public GameObject effect;
    public GameObject cursor;
    public GameObject eventManager;

    private HoloGuideInput manipulateHand;


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();

            if (manipulateHand.airTap == true)
            {
                manipulateHand.airTap = false;

            }
            else if (manipulateHand.drag == true)
            {
                effect.transform.position = cursor.transform.position;
                clockContent.transform.position = effect.transform.position;

            }

        }

    }


}
