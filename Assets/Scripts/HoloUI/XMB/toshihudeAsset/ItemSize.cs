using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSize : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y >= 100 && this.transform.position.y <= 120)
        {
            this.transform.localScale = new Vector2(1.2f, 1.2f);
        }
        else
        {
            this.transform.localScale = new Vector2(1f, 1f);
        }


    }
}