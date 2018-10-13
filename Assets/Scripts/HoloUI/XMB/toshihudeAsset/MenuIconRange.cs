using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIconRange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(this.transform.localPosition.x >=0)
        {
            this.transform.localPosition = new Vector3(0, 50, 10);
        }
        if (this.transform.localPosition.x <= -260)
        {
            this.transform.localPosition = new Vector3(-260, 50, 10);
        }
    }
}
