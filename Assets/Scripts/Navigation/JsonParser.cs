using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HoloToolkit.Unity;

public class JsonParser : Singleton<JsonParser>
{
    public Navigator navigator;
    public LocateMap locateMap;

    public void ParseJson(string json)
    {
        Debug.Log(json);

        var jObject = JObject.Parse(json);
        switch(jObject["type"].Value<string>())
        {
            case "setting":
                // 設定
                navigator.setting = JsonConvert.DeserializeObject<HoloGuide.Setting>(json);
                break;
            case "route":
                navigator.route = JsonConvert.DeserializeObject<HoloGuide.Route>(json);
                break;
            case "location":
                // 位置情報変更時
                var location = JsonConvert.DeserializeObject<HoloGuide.Location>(json);
                Debug.Log(string.Format("lat: {0}, lng: {1}", location.lat, location.lng));
                break;
            default:
                break;
                
        }
        
    }

}

namespace HoloGuide
{
    [System.Serializable]
    public class Setting
    {
        public string type { get; set; }
        public string dummy { get; set; }
    }

    [System.Serializable]
    public class Location
    {
        public string type { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public long updated { get; set; }
    }

    [System.Serializable]
    public class Route
    {
        public string type { get; set; }
        public string filename { get; set; }
        public int start { get; set; }
        public int goal { get; set; }
    }

    [System.Serializable]
    public class State
    {
        public string type = "state";
        public bool isNavigating;
    }

}
