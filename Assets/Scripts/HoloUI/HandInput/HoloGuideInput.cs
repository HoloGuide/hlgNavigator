using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoloGuideInput : MonoBehaviour
{
    public bool press;
    public bool airTap;
    public bool drag;

    public float touchAndHoldSeconds;
    public float BoundaryOfTapAndDrag;

    public float tx;
    public float ty;

    public GameObject cursortest;
    public GameObject referenceCanvas;

    // Use this for initialization

    void Start()
    {
        cursortest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursortest.SetActive(true);
        }

        if (Input.GetMouseButton(0))//手の認識中の代用
        {
            HandTrackingMode();

            if (Input.GetKey("m"))//airtap中の代用
            {

                EnterTap();

            }
            if (Input.GetKeyUp("m"))
            {
                press = false;
                if (drag == true)
                {
                    drag = false;
                    touchAndHoldSeconds = 0;
                }
                else if (touchAndHoldSeconds < BoundaryOfTapAndDrag && drag == false)
                {

                    airTap = true;
                    touchAndHoldSeconds = 0;
                    Invoke("AirTapEnd", 0.5f);

                }

            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            cursortest.SetActive(false);
        }

    }

    public void HandTrackingMode()
    {
        cursortest.transform.localPosition = new Vector3(Input.mousePosition.x + tx, Input.mousePosition.y + ty, referenceCanvas.transform.position.z);
    }

    public void EnterTap()
    {
        
        if (drag == true)
        {
            press = false;
        }
        else
        {
            press = true;
        }
        touchAndHoldSeconds += Time.deltaTime;
        if (touchAndHoldSeconds > BoundaryOfTapAndDrag && drag == false)
        {
         
            drag = true;
            
        }


    }
    public void AirTapEnd()
    {
        airTap = false;
    }
}