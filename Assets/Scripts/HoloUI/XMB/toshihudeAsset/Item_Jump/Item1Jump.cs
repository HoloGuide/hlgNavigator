using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1Jump : MonoBehaviour
{
    public float menu_itemposY;
    public GameObject menuitem;
    public float ItemposX;
    public Vector3 itempos;
    public bool jump;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        menuitem = gameObject.transform.parent.gameObject;//親をぶちこんで
        menu_itemposY = menuitem.transform.localPosition.y;//親のローカルポジションをぶつこんで
        itempos = this.transform.localPosition;//自分のローカルポジションをぶち込んで
        if ((menu_itemposY >= 50) && (jump == false))
        {
            this.transform.localPosition = new Vector3(itempos.x/*動かない*/, 50, 0);
            jump = true;
        }
        else if (menu_itemposY < 50)
        {
            this.transform.localPosition = new Vector3(itempos.x, -50, 0);
            jump = false;
        }
    }
}

