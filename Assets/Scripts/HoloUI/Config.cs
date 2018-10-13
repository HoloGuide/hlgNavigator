using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//設定ファイルの形式がよくわからなかったのでとりあえず作ったもの
public class Config : MonoBehaviour
{ 
    public bool mapPower = false;
    public bool routePower = true;
    public bool linePower = true;
    public bool clockPower = true;
    public bool noticePower = true;
    public bool menuPower = false;

    public int mapScale = 1;
    public int routeScale = 1;
    public int lineScale = 1;
    public int clockScale = 1;
    public int noticeScale = 1;

    public int mapTranslucent = 100;
    public int routeTranslucent = 100;
    public int lineTranslucent = 100;
    public int clockTranslucent = 100;
    public int noticeTranslucent = 100;

    public int sizeConTargetObject = 0;
}