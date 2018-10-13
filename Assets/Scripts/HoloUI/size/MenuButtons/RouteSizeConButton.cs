﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSizeConButton : MonoBehaviour
{

    public Vector3 canEnterPosition;

    public GameObject sizeConWindow;
    public GameObject eventManager;

    private HoloGuideInput manipulateHand;
    private Config targetObject;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();
            targetObject = eventManager.GetComponent<Config>();

            if (manipulateHand.airTap == true && this.transform.position == canEnterPosition)
            {
                if (sizeConWindow.activeSelf == false)
                {
                    targetObject.sizeConTargetObject = 2;
                    sizeConWindow.SetActive(true);

                }

                manipulateHand.airTap = false;

            }

        }

    }


}