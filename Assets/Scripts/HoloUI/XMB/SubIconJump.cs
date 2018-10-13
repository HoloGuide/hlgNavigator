using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubIconJump : MonoBehaviour {


    public float underSkipPosition;
    public float upperSkipPosition;
    public GameObject myself;
    public GameObject subIcons;
   
	// Update is called once per frame
	void Update () {



        if (subIcons.transform.localPosition.y == underSkipPosition)
        {
            myself.transform.localPosition = new Vector3(myself.transform.localPosition.x, myself.transform.localPosition.y + 200, myself.transform.localPosition.z);
        }
        else if(subIcons.transform.position.y == upperSkipPosition)
        {
            myself.transform.localPosition = new Vector3(myself.transform.localPosition.x, myself.transform.localPosition.y - 200, myself.transform.localPosition.z);
        }
    }
}
