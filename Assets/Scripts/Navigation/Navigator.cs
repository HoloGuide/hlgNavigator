using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloGuide;
using System;

public class Navigator : MonoBehaviour
{
    public NavigationController NavController;
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

    public Route route
    {
        get
        {
            return _route;
        }
        set
        {
            actionDoMainThreads.Enqueue(() =>
            {
                OnRouteChanged(value);
            });
            _route = value;
        }
    }
    private Route _route = null;

    private Queue<Action> actionDoMainThreads = new Queue<Action>();

    private void OnSettingChanged(Setting set)
    {
        // 設定変更時に呼ばれる
        
    }

    private void OnRouteChanged(Route route)
    {
        Debug.Log("Navigator OnRouteChanged called.");
        NavController.OnRouteChanged();

        // var map = MapLoader.Load(route.map);
        var map = MapLoader.Load(route.filename);
        Debug.Log("Loading map ok.");

        // Navigate(map, route.src, map.dst);
        Navigate(map, route.start, route.goal);

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
        while (actionDoMainThreads.Count > 0)
        {
            var action = actionDoMainThreads.Dequeue();

            action?.Invoke();
        }
    }
}
