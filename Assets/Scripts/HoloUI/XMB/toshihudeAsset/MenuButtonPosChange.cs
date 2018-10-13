using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonPosChange : MonoBehaviour
{
    private Vector3 click, offset;//click…クリックされた座標 offset…マウス座標とIcon座標の差。
    public GameObject menuButtons;//空のオブジェクト
    public bool drag;//マウスが押されているかの有無
    public float ButtonPosX;//ButtonのX座標

    // Use this for initialization
    void Start()
    {
        drag = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            click = Input.mousePosition;
            offset = menuButtons.transform.localPosition - click;
            drag = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            drag = false;
        }

        if (drag == true)
        {
            DragMode();
        }
    }

    void DragMode()
    {
        //Icon座標にoffsetの値を足すことで、Icon座標がマウス座標になるのを防ぐ。
        menuButtons.transform.localPosition = new Vector3(ButtonPosX, Input.mousePosition.y + offset.y, 0);
    }
}
