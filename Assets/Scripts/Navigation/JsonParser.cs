using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Newtonsoft.Json;
using HoloToolkit.Unity;

public class JsonParser : Singleton<JsonParser>
{
    public LocateMap locateMap;

    public void ParseJson(string json)
    {
        if (json == "DEBUG, DELETE ANCHOR")
        {
            locateMap.DeleteAnchor();
        }

        Debug.Log(json);
    }

}
