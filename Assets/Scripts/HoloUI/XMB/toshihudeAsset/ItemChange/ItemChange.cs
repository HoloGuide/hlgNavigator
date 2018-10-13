using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChange : MonoBehaviour
{
    public float MainIconPosX;
    public GameObject LookedImage;
    public GameObject ViewHideItem;
    public int MaxImageRange;
    public int MinImageRange;

    public Vector3 MainIconPos;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //imageの位置を取得
        MainIconPos = LookedImage.transform.position;
        MainIconPosX = MainIconPos.x;

        //imageの位置で表示・非表示を判定
        //Min…以上Max…以下に
        if (MainIconPosX >= MinImageRange && MainIconPosX <= MaxImageRange)
        {
            ViewHideItem.GetComponent<UnityEngine.UI.Image>().enabled = true;
        }
        else if (MainIconPosX < MinImageRange || MainIconPosX > MaxImageRange)
        {
            ViewHideItem.GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
    }
}
