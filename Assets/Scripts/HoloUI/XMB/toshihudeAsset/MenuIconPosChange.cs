using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuIconPosChange : MonoBehaviour {
    private Vector3 click, offset;//click…クリックされた座標 offset…マウス座標とIcon座標の差。
    public GameObject menuIcons;//空のオブジェクト
    public bool drag;//マウスが押されているかの有無
    public float IconPosY;//IconのY座標


	// Use this for initialization
	void Start () {
        drag = false;
	}
	
	// Update is called once per frame
	void Update () {
        
		if (Input.GetMouseButtonDown(0))
        {
            click = Input.mousePosition;
            offset = menuIcons.transform.localPosition - click;
            drag = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            drag = false;
        }

        if(drag == true)
        {
            DragMode();
        }
	}

    void DragMode()
    {
        //Icon座標にoffsetの値を足すことで、Icon座標がマウス座標になるのを防ぐ。
        menuIcons.transform.localPosition = new Vector3(Input.mousePosition.x + offset.x,IconPosY,0);
    }
}
