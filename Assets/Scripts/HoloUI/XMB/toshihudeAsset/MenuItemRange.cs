using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemRange : MonoBehaviour
{
    public int Itemposx;
    // Use this for initialization
    void Start()
    {    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localPosition.y >= 145)
        {
            this.transform.localPosition = new Vector3(Itemposx, 145, 00);
        }
        if (this.transform.localPosition.y <= -5)
        {
            this.transform.localPosition = new Vector3(Itemposx, -5, 00);
        }
    }
}
