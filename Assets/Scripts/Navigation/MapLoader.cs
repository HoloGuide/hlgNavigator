using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using HoloGuide;
using HoloGuide.PathFinding;
using UnityEngine;

#if !UNITY_EDITOR && UNITY_WSA
using Windows.Storage;
#endif

public class MapLoader
{
    /// <summary>
    /// ファイル保存先 (デバイス依存)
    /// </summary>
    private static string SavePath
    {
        get
        {
#if !UNITY_EDITOR && UNITY_WSA
            return ApplicationData.Current.RoamingFolder.Path;
#else
            return Application.persistentDataPath;
#endif
        }
    }

    public static Map Load(string filename)
    {
        string json = "";
        using (System.IO.Stream stream = OpenFileHelper.OpenFileForRead(SavePath, filename))
        {
            byte[] _data = new byte[stream.Length];
            stream.Read(_data, 0, (int)stream.Length);
            json = System.Text.Encoding.UTF8.GetString(_data);
        }

        return LoadMap(json);
    }

    private static Map LoadMap(string json)
    {
        var map = JsonConvert.DeserializeObject<Map>(json);

        var _p = new Dictionary<int, Point>();
        map.Points.ForEach(p => _p.Add(p.Id, new Point(p.Id, p.Name, p.Position)));

        foreach (var path in map.Paths)
        {
            var src = _p[path.Src];
            var dst = _p[path.Dst];
            var d = GetDistance(
                src.Position.x - dst.Position.x,
                src.Position.y - dst.Position.y,
                src.Position.z - dst.Position.z);
            if (!UseDist) d = 0;

            src.AddPoint(dst, path.Cost + d);
            dst.AddPoint(src, path.Cost + d);
        }

        map._points = _p;
        return map;
    }

    private static double GetDistance(double dx, double dy, double dz) => Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2));

    public static bool UseDist = true;
}

namespace HoloGuide
{
    [Serializable]
    public class Map
    {
        public string Id;
        public string Name;
        public string AnchorId;
        public string RoomId;
        public List<Point> Points;
        public List<Path> Paths;

        [JsonIgnore]
        public Dictionary<int, Point> _points;

    }

}

