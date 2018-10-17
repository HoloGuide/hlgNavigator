using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//設定やシーンに従って実際にオブジェクトの状態を切り替える
public class ContentsVisible : MonoBehaviour {

    public GameObject map;
    public GameObject route;
    //public GameObject line;
    public GameObject clock;
    // public GameObject notice;
    public GameObject OverRayContent;
    public GameObject menu;
    public bool editMode;
    private Config powerSetting;


    void Start()
    {
        powerSetting = GetComponent<Config>();

        if (powerSetting.mapPower == true)
        {
            map.SetActive(true);
        
        }
        else if (powerSetting.mapPower == false)
        {
            map.SetActive(false);

        }

        if (powerSetting.routePower == true)
        {
            route.SetActive(true);

        }
        else
        {
            route.SetActive(false);

        }

        /*if (powerSetting.linePower == true)
        {
            line.SetActive(true);

        }
        else
        {
            line.SetActive(false);

        }
        */

        if (powerSetting.clockPower == true)
        {
            clock.SetActive(true);

        }
        else
        {
            clock.SetActive(false);

        }

        //if (powerSetting.noticePower == true)
        //{
        //    notice.SetActive(true);

        //}
        //else
        //{
        //    notice.SetActive(false);

        //}

    }


    public void MenuAlive()
    {
        // OverRayContent.transform.Translate(0f, 720f, 0f);//コンテンツを見えなくするため
        map.SetActive(false);
        route.SetActive(false);
        clock.SetActive(false);
    }


    public void MenuDead()
    {
        // OverRayContent.transform.Translate(0f, -720f, 0f);
        map.SetActive(true);
        route.SetActive(true);
        clock.SetActive(true);

        if (powerSetting.mapPower == true)
        {
            map.SetActive(true);

        }
        else if (powerSetting.mapPower == false)
        {
            map.SetActive(false);

        }

        if (powerSetting.routePower == true)
        {
            route.SetActive(true);

        }
        else
        {
            route.SetActive(false);

        }

        /*if (powerSetting.linePower == true)
        {
            line.SetActive(true);

        }
        else
        {
            line.SetActive(false);

        }
        */
        if (powerSetting.clockPower == true)
        {
            clock.SetActive(true);

        }
        else
        {
            clock.SetActive(false);

        }

        //if (powerSetting.noticePower == true)
        //{
        //    notice.SetActive(true);

        //}
        //else
        //{
        //    notice.SetActive(false);

        //}
        
        menu.SetActive(false);

    }


}
