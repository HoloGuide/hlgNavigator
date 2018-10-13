using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloGuide;

public class Navigator : MonoBehaviour
{
    public LineRenderer GuideLine;
    public LocateMap locateMap;
    public RoomLoader roomLoader;

    public Setting setting
    {
        get
        {
            return _setting;
        }
        set
        {
            OnSettingChanged(value);
            _setting = value;
        }
    }
    private Setting _setting = null;

    private void OnSettingChanged(Setting set)
    {
        // 設定変更時に呼ばれる
        Debug.Log("Setting/dummy: " + set.dummy);
    }

    private void OnRouteChanged(/*Route route*/)
    {
        // var map = MapLoader.Load(route.map);
        var map = MapLoader.Load(@"F:\ziyuu29\map_test.json");
        // Navigate(map, route.src, map.dst);
        Navigate(map, 1, 6);

        locateMap.AnchorID = map.AnchorId;
        roomLoader.RoomId = map.RoomId;
        locateMap.Locate();
    }

    private void Navigate(Map map, int startId, int goalId)
    {
        var pathFinder = new PathFinder(map);
        pathFinder.ResetCosts();
        var path = pathFinder.Trace(startId, goalId);

        for(int i = 0; i < path.Count; i++)
        {
            Debug.Log(i + ": " + path[i].Name);
        }

        GuideLine.positionCount = path.Count;
        GuideLine.SetPositions(path.Select(p => p.Position.ToVector3()).ToArray());
    }

    private void Start()
    {
        
    }

    private void Update()
    {

    }
}
