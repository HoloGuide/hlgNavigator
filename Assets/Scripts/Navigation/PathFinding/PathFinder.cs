using System.Linq;
using System.Collections.Generic;

using HoloGuide;
using HoloGuide.PathFinding;

/// <summary>
/// ダイクストラ法による最短経路探索
/// (https://qiita.com/edo_m18/items/0588d290a19f2afc0a84)
/// </summary>
public class PathFinder
{
    public PathFinder(Map map)
    {
        _points = map._points;
    }

    /// <summary>
    /// 最短経路をトレースします。
    /// </summary>
    /// <param name="startId">開始地点</param>
    /// <param name="goalId">目標地点</param>
    /// <returns>経由するポイントのリスト(開始・目標含む、Reverse済み)</returns>
    public List<Point> Trace(int startId, int goalId)
    {
        var start = _points[startId];
        var goal = _points[goalId];

        if (!setCosts(start))
        {
            return null;
        }

        var ret = new List<Point>();

        ret.Add((Point)goal.Clone());
        var p = goal;

        while (true)
        {
            p = p.PrevPoint;

            if (p == null || p.PrevPoint == null) break;

            ret.Add((Point)p.Clone());
        }

        ret.Add((Point)start.Clone());

        ret.Reverse();

        return ret;

    }

    /// <summary>
    /// 各辺のコスト(重み)を設定します。
    /// </summary>
    /// <returns>成功かどうか</returns>
    private bool setCosts(Point start)
    {
        start.SetCost(0);

        for (int i = 0; i < _points.Count; i++)
        {
            if (!_points.Any(n => !n.Value.IsDone && n.Value.Cost >= 0))
            {
                // グラフが連結ではない
                return false;
            }

            double min = _points.Where(n => !n.Value.IsDone && n.Value.Cost >= 0).Min(n => n.Value.Cost);

            Point minNode = _points.First(n => !n.Value.IsDone && n.Value.Cost == min).Value;

            minNode.UpdateCost();
            minNode.Done();
        }

        return true;
    }

    public void ResetCosts()
    {
        foreach (var node in _points)
        {
            node.Value.Reset();
        }
    }

    /// <summary>
    /// 接点
    /// </summary>
    private Dictionary<int, Point> _points { get; set; }
}

namespace HoloGuide.PathFinding
{
    [System.Serializable]
    public class Vec3
    {
        public double x, y, z;
        public UnityEngine.Vector3 ToVector3()
        {
            return new UnityEngine.Vector3((float)x, (float)y, (float)z);
        }
    }

    [System.Serializable]
    public class Path
    {
        public int Src;
        public int Dst;
        public double Cost;
    }

}

