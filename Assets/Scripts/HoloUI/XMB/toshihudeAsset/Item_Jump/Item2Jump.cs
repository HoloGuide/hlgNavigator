using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2Jump : MonoBehaviour
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
        menuitem = gameObject.transform.parent.gameObject;
        menu_itemposY = menuitem.transform.localPosition.y;
        itempos = this.transform.localPosition;
        if ((menu_itemposY >= 100) && (jump == false))
        {
            this.transform.localPosition = new Vector3(itempos.x, 0, 0);
            jump = true;
        }
        else if (menu_itemposY < 100)
        {
            this.transform.localPosition = new Vector3(itempos.x, -100, 0);
            jump = false;
        }
    }
}

