using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutePositionChangeButton : MonoBehaviour
{

    public GameObject effectRoute;
    public GameObject eventManager;
    public GameObject menuContent;
    public GameObject editContent;

    private HoloGuideInput manipulateHand;
    private ContentsVisible editMode;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();

            if (manipulateHand.airTap == true)
            {
                editMode = eventManager.GetComponent<ContentsVisible>();
                editMode.editMode = true;
                menuContent.SetActive(false);
                editContent.transform.localPosition = new Vector3(0, 0, 0);
                effectRoute.SetActive(true);
                manipulateHand.airTap = false;

            }

        }

    }


}

