using System;
using System.Collections.Generic;

namespace HoloGuide.PathFinding
{
    /// <summary>
    /// 点, 経由地
    /// </summary>
    public class Point : ICloneable
    {
        /// <summary>
        /// Pointを作成します。
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">名前</param>
        /// <param name="position">位置</param>
        public Point(int id, string name, Vec3 position)
        {
            _edges = new Dictionary<Point, double>();
            Cost = -1;
            IsDone = false;
            PrevPoint = null;
            Position = position;
            Id = id;
            Name = name;
        }

        public object Clone()
        {
            return (Point)this.MemberwiseClone();
        }

        /// <summary>
        /// 接続されているPointを追加します。
        /// </summary>
        public void AddPoint(Point p, double cost)
        {
            _edges.Add(p, cost);
        }

        /// <summary>
        /// 最短コストを確定させます。
        /// </summary>
        public void Done()
        {
            IsDone = true;
        }

        /// <summary>
        /// 直前のPointを設定します。
        /// </summary>
        public void SetPrevPoint(Point prev)
        {
            PrevPoint = prev;
        }

        /// <summary>
        /// コストを設定します。
        /// </summary>
        public void SetCost(double cost)
        {
            Cost = cost;
        }

        /// <summary>
        /// 接続されている接点のコストを更新します。
        /// </summary>
        public void UpdateCost()
        {
            if (IsDone) return;

            foreach (var edge in _edges)
            {
                if (edge.Key.Cost < 0 || (Cost + edge.Value) < edge.Key.Cost)
                {
                    edge.Key.SetCost(Cost + edge.Value);
                    edge.Key.SetPrevPoint(this);
                }
            }
        }

        public void Reset()
        {
            IsDone = false;
            Cost = -1;
            PrevPoint = null;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} ({Cost})";
        }

        /// <summary>
        /// 接続されているノード と 各辺のコスト (重み)
        /// </summary>
        [Newtonsoft.Json.JsonIgnore()]
        public Dictionary<Point, double> _edges { get; set; }

        /// <summary>
        /// コスト (スタートからの最短距離)
        /// </summary>
        public double Cost { get; private set; }

        /// <summary>
        /// 最短コストが確定済みか
        /// </summary>
        [Newtonsoft.Json.JsonIgnore()]
        public bool IsDone { get; private set; }

        /// <summary>
        /// 最短ルートでの直前に訪問したPoint
        /// </summary>
        [Newtonsoft.Json.JsonIgnore()]
        public Point PrevPoint { get; private set; }

        /// <summary>
        /// 座標
        /// </summary>
        public Vec3 Position { get; private set; }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// 識別名
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// 階
        /// </summary>
        public int Floor { get; private set; }

    }
}