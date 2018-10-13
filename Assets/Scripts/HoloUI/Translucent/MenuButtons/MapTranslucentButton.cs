using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTranslucentButton : MonoBehaviour {

    public Vector3 canEnterPosition;

    public GameObject translucentConWindow;
    public GameObject eventManager;

    private HoloGuideInput manipulateHand;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();

            if (manipulateHand.airTap == true && this.transform.position == canEnterPosition)
            {
                if (translucentConWindow.activeSelf == false)
                {
                    translucentConWindow.SetActive(true);

                }

                manipulateHand.airTap = false;

            }

        }

    }


}
