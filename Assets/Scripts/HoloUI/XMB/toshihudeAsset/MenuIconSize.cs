using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIconSize : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (this.transform.position.x >= 70 && this.transform.position.x <= 110)
        {
            this.transform.localScale = new Vector2(1.2f, 1.2f);
        }
        else
        {
            this.transform.localScale = new Vector2(1f, 1f);
        }

        
	}
}
