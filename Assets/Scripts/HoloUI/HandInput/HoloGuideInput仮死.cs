/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.WSA;
using UnityEngine.XR.WSA.Persistence;
using UnityEngine.XR.WSA.Input;

public class HoloGuideInput : MonoBehaviour
{
    public bool airTap;
    public bool drag;
    public bool press;

    public float touchAndHoldSeconds;
    public float boundaryOfTapAndDrag;

    private Vector2 cursorPosition;
    private Vector3 handPosition;
    private Vector3 handpos2;

    public RectTransform canvasRect;

    public Canvas canvas;
    public Camera uiCamera;
    public Camera worldCamera;
    public Camera hololensCamera;
    public GameObject cursor;
    public GameObject cursor2;
    
    
    
    

    void Start()
    {
        InteractionManager.InteractionSourceDetected += SourceDetected;
        InteractionManager.InteractionSourceUpdated += SourceUpdated;
        InteractionManager.InteractionSourceLost += SourceLost;
        InteractionManager.InteractionSourcePressed += SourcePressed;
        InteractionManager.InteractionSourceReleased += SourceReleased;

        cursor.SetActive(false);
        cursorPosition = Vector2.zero;
        uiCamera = hololensCamera;
        worldCamera = hololensCamera;
        canvasRect = canvas.GetComponent<RectTransform>();
    }

    //Dragを可能にするためにUpdate関数に入れる必要があった
    void Update()
    {
        if (press == true)
        {
            touchAndHoldSeconds += Time.deltaTime;
        }

        if (touchAndHoldSeconds > boundaryOfTapAndDrag)
        {
            press = false;
            drag = true;
                
        }
        
    }

    void SourceDetected(InteractionSourceDetectedEventArgs state)//手が認識した瞬間
    { 
        cursor.SetActive(true);
        
    }


    void SourceUpdated(InteractionSourceUpdatedEventArgs state)//手が認識されている間
    {
       
        if (state.state.sourcePose.TryGetPosition(out handPosition))//手の位置はVector3のワールド座標として扱われる
        {
            //CanvasはScreenSpaceCameraなのでワールド座標をスクリーン座標に変換しないといけない
            var screenPos = RectTransformUtility.WorldToScreenPoint(worldCamera, handPosition);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, uiCamera, out cursorPosition);
            cursor.transform.localPosition = cursorPosition;

        }

    }


    void SourceLost(InteractionSourceLostEventArgs state)//手が認識できなくなった瞬間
    {    
        cursor.SetActive(false);

        touchAndHoldSeconds = 0;
        airTap = false;
        drag = false;
        
    }

    void SourcePressed(InteractionSourcePressedEventArgs state)//手を認識している間に、指が倒された瞬間
    {
        press = true;

    }


    void SourceReleased(InteractionSourceReleasedEventArgs state)//指が倒された後、指を戻した瞬間
    {
        press = false;

        if (drag == true)
        {
            drag = false;
            touchAndHoldSeconds = 0;

        }
        else if (drag == false)
        {
            airTap = true;
            touchAndHoldSeconds = 0;
            Invoke("AirTapEnd", 0.5f);

        }
    }
    
   
    public void AirTapEnd() //AirTapを確実に終わらせるための関数
    {
        airTap = false;

    }


}
*/