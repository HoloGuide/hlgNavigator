using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourSubIconsVertical : MonoBehaviour
{

    private Vector3 offSet;

    public GameObject eventManager;
    public GameObject cursor;
    public GameObject subIcons;
    public GameObject referenceCanvas;
    public GameObject anchor;
    public GameObject firstIcon;
    public GameObject secondIcon;
    public GameObject thirdIcon;
    public GameObject fourthIcon;

    private HoloGuideInput manipulateHand;
    private ContentsVisible menuState;
    private Config powerSetting;


    public void Start()
    {
        manipulateHand = eventManager.GetComponent<HoloGuideInput>();
        powerSetting = eventManager.GetComponent<Config>();
        menuState = eventManager.GetComponent<ContentsVisible>();

    }


    public void Update()
    {
        manipulateHand = eventManager.GetComponent<HoloGuideInput>();
        if (manipulateHand.drag == false)
        {
            SubIconsPositionFix();
        }

        if (subIcons.transform.localPosition.y <= 100)
        {
            firstIcon.transform.localPosition = new Vector3(0f, -200f, 0f);
            secondIcon.transform.localPosition = new Vector3(0f, -400f, 0f);
            thirdIcon.transform.localPosition = new Vector3(0f, -600f, 0f);
            fourthIcon.transform.localPosition = new Vector3(0f, -800f, 0f);
        }
        else if (subIcons.transform.localPosition.y <= 300 && subIcons.transform.localPosition.y >= 100)
        {
            firstIcon.transform.localPosition = new Vector3(0f, 0f, 0f);
            secondIcon.transform.localPosition = new Vector3(0f, -400f, 0f);
            thirdIcon.transform.localPosition = new Vector3(0f, -600f, 0f);
            fourthIcon.transform.localPosition = new Vector3(0f, -800f, 0f);
        }
        else if (subIcons.transform.localPosition.y <= 500 && subIcons.transform.localPosition.y >= 300)
        {
            firstIcon.transform.localPosition = new Vector3(0f, 0f, 0f);
            secondIcon.transform.localPosition = new Vector3(0f,  -200f, 0f);
            thirdIcon.transform.localPosition = new Vector3(0f, -600f, 0f);
            fourthIcon.transform.localPosition = new Vector3(0f, -800f, 0f);
        }
        else if (subIcons.transform.localPosition.y <= 700 && subIcons.transform.localPosition.y >= 500)
        {
            firstIcon.transform.localPosition = new Vector3(0f, 0f, 0f);
            secondIcon.transform.localPosition = new Vector3(0f, -200f, 0f);
            thirdIcon.transform.localPosition = new Vector3(0f, -400f, 0f);
            fourthIcon.transform.localPosition = new Vector3(0f, -800f, 0f);
        }
        else if (subIcons.transform.localPosition.y >= 700)
        {
            firstIcon.transform.localPosition = new Vector3(0f, 0f, 0f);
            secondIcon.transform.localPosition = new Vector3(0f, -200f, 0f);
            thirdIcon.transform.localPosition = new Vector3(0f, -400f, 0f);
            fourthIcon.transform.localPosition = new Vector3(0f, -600f, 0f);
        }

    }


    public void SubIconsPositionFix()
    {
        if (subIcons.transform.localPosition.y <= 100f)
        {
            subIcons.transform.localPosition = new Vector3(0f, 0f, 0f)

;
        }
        else if (subIcons.transform.localPosition.y <= 300f && subIcons.transform.localPosition.y >= 100f)
        {
            subIcons.transform.localPosition = new Vector3(0f, 200f, 0f);

        }
        else if (subIcons.transform.localPosition.y < 500f && subIcons.transform.localPosition.y >= 300f)
        {
            subIcons.transform.localPosition = new Vector3(0f, 400f, 0f);

        }
        else if (subIcons.transform.localPosition.y >= 500f)
        {
            subIcons.transform.localPosition = new Vector3(0f, 600f, 0f);
        }

    }


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cursor")
        {
            manipulateHand = eventManager.GetComponent<HoloGuideInput>();
            powerSetting = eventManager.GetComponent<Config>();
            menuState = eventManager.GetComponent<ContentsVisible>();

            if (manipulateHand.press == true && manipulateHand.drag == false)
            {
                offSet = subIcons.transform.position - cursor.transform.position;

            }

            if (manipulateHand.drag == true)
            {
                if (menuState.editMode == false)
                {
                    subIcons.transform.position = new Vector3(anchor.transform.position.x, cursor.transform.position.y + offSet.y, referenceCanvas.transform.position.z);

                }

            }

        }

    }


}
    