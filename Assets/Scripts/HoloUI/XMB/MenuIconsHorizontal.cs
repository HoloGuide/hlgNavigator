using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuIconsHorizontal : MonoBehaviour {

    //private bool noControl = false;

    private Vector3 offSet;

    public GameObject eventManager;
    public GameObject cursor;
    public GameObject menuIcons;
    public GameObject emergencyIcons;
    public GameObject mapIcons;
    public GameObject routeIcons;
    public GameObject lineIcons;
    public GameObject clockIcons;
    public GameObject noticeIcons;
    public GameObject referenceCanvas;
    public GameObject anchor;
    public GameObject iconMask;

    private HoloGuideInput manipulateHand;
    private ContentsVisible menuState;
    private Config powerSetting;

    public void Start()
    {
        manipulateHand = eventManager.GetComponent<HoloGuideInput>();
        powerSetting = eventManager.GetComponent<Config>();
        menuState = eventManager.GetComponent<ContentsVisible>();
        /*emergencyIcons.SetActive(false);
        mapIcons.SetActive(true);
        routeIcons.SetActive(false);
        lineIcons.SetActive(false);
        clockIcons.SetActive(false);
        noticeIcons.SetActive(false);*/

    }


    public void Update()
    {
        manipulateHand = eventManager.GetComponent<HoloGuideInput>();
        if (manipulateHand.drag == false)
        {
            IconsPositionFix();
        }

        if (menuIcons.transform.localPosition.x >= 125f && menuIcons.transform.localPosition.x <= 375f)
        {
            emergencyIcons.SetActive(true);
            mapIcons.SetActive(false);
            routeIcons.SetActive(false);
            lineIcons.SetActive(false);
            clockIcons.SetActive(false);
            noticeIcons.SetActive(false);
        }
        else if (menuIcons.transform.localPosition.x <= 125f && menuIcons.transform.localPosition.x >= -125f)
        {
            emergencyIcons.SetActive(false);
            mapIcons.SetActive(true);
            routeIcons.SetActive(false);
            lineIcons.SetActive(false);
            clockIcons.SetActive(false);
            noticeIcons.SetActive(false);

        }
        else if (menuIcons.transform.localPosition.x <= -125f && menuIcons.transform.localPosition.x >= -375f )
        {
            emergencyIcons.SetActive(false);
            mapIcons.SetActive(false);
            routeIcons.SetActive(true);
            lineIcons.SetActive(false);
            clockIcons.SetActive(false);
            noticeIcons.SetActive(false);

        }
        else if (menuIcons.transform.localPosition.x <= -375f && menuIcons.transform.localPosition.x >= -625f)
        {
            emergencyIcons.SetActive(false);
            mapIcons.SetActive(false);
            routeIcons.SetActive(false);
            lineIcons.SetActive(true);
            clockIcons.SetActive(false);
            noticeIcons.SetActive(false);

        }
        else if (menuIcons.transform.localPosition.x <= -625f && menuIcons.transform.localPosition.x >= -875f)
        {
            emergencyIcons.SetActive(false);
            mapIcons.SetActive(false);
            routeIcons.SetActive(false);
            lineIcons.SetActive(false);
            clockIcons.SetActive(true);
            noticeIcons.SetActive(false);

        }
        else if (menuIcons.transform.localPosition.x <= -875f && menuIcons.transform.localPosition.x >= -1125)
        {
            emergencyIcons.SetActive(false);
            mapIcons.SetActive(false);
            routeIcons.SetActive(false);
            lineIcons.SetActive(false);
            clockIcons.SetActive(false);
            noticeIcons.SetActive(true);

        }

        iconMask.transform.position = menuIcons.transform.position;
    }


    public void IconsPositionFix()
    {
        /*if (menuIcons.transform.position.x > 375f)
        {
            menuIcons.transform.position = new Vector3(500f, menuIcons.transform.position.y, 0f);

        }else*/

        if (menuIcons.transform.localPosition.x > 125f)
        {
            menuIcons.transform.localPosition = new Vector3(250f, 190f,0f);

        }
        else if (menuIcons.transform.localPosition.x <= 125f && menuIcons.transform.localPosition.x > -125f)
        {
            menuIcons.transform.localPosition = new Vector3(0f, 190f,0f);

        }
        else if(menuIcons.transform.localPosition.x <= -125f && menuIcons.transform.localPosition.x > -375f)
        {
            menuIcons.transform.localPosition = new Vector3(-250f, 190f,0f);

        }
        else if(menuIcons.transform.localPosition.x <= -375f && menuIcons.transform.localPosition.x > -625f)
        {
            menuIcons.transform.localPosition = new Vector3(-500f, 190f,0f);

        }
        else if (menuIcons.transform.localPosition.x <= -625f && menuIcons.transform.localPosition.x > -875f)
        {
            menuIcons.transform.localPosition = new Vector3(-750f, 190f,0f);

        }
        else if (menuIcons.transform.localPosition.x <= -875f)
        {
            menuIcons.transform.localPosition = new Vector3(-1000f, 190f,0f);
       
        }
        //以下新しいアイコンが横方向に追加されたら処理を追加

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
                offSet = menuIcons.transform.position - cursor.transform.position;

            }

            if (manipulateHand.drag == true)
            {
                if (menuState.editMode == false)
                {
                    menuIcons.transform.position = new Vector3(cursor.transform.position.x + offSet.x, anchor.transform.position.y,referenceCanvas.transform.position.z);

                }

            }

        }

    }


}
        

                