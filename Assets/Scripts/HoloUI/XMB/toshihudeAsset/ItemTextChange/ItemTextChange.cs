using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTextChange : MonoBehaviour {

    public float MainIconPosX;

    public Vector3 MainIconPos;
    public GameObject LookedImage;
    public GameObject ViewHideText;

    // Use this for initialization
    void Start()
    {

    }
	// Update is called once per frame
	void Update () {
        //imageの位置を取得
        MainIconPos = LookedImage.transform.position;
        MainIconPosX = MainIconPos.x;

        //imageの位置で表示・非表示を判定
        if (MainIconPosX >= 70 && MainIconPosX <= 110)
        {
            ViewHideText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        }
        else if (MainIconPosX < 70 || MainIconPosX > 110)
        {
            ViewHideText.GetComponent<UnityEngine.UI.Text>().enabled = false;
        }
    }
}
