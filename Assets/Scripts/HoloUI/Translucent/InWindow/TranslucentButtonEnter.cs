using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslucentButtonEnter : MonoBehaviour {

    public GameObject translucentConWindow;
    public GameObject eventManager;

    private HoloGuideInput manipulateHand;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();

            if (manipulateHand.airTap == true)
            {
                if (translucentConWindow.activeSelf == true)
                {
                    translucentConWindow.SetActive(false);

                }

                manipulateHand.airTap = false;

            }

        }

    }


}
