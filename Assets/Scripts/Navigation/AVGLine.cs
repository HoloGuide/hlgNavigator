using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloToolkit.Unity;

[RequireComponent(typeof(LineRenderer))]
public class AVGLine : Singleton<AVGLine>
{
    public Shader LineShader;

    public List<Vector3> LineVects { get; private set; }

    private LineRenderer m_lineRenderer;

    /// <summary>
    /// 回帰直線を計算する
    /// </summary>
    public void Calculate(List<Vector3> vects)
    {
        // 交点が取得できていない点(値が100)を除外
        vects.RemoveAll(v => v.x == 100);

        if (vects.Count == 0) return;

        // 平均
        float aveX = vects.Average(v => v.x);
        float aveZ = vects.Average(v => v.z);

        // 偏差
        float devX = 0, devZ = 0;
        // 共分散
        float CovXZ = 0;
        // 分散
        float varX = 0, varZ = 0;

        // 共分散と分散を計算
        foreach (var v in vects)
        {
            devX = v.x - aveX;
            devZ = v.z - aveZ;
            CovXZ += devX * devZ;
            varX += devX * devX;
            varZ += devZ * devZ;
        }

        // 傾き
        var a = CovXZ / varX;
        // 切片
        var b = aveZ - a * aveX;

        // 回帰直線を計算
        LineVects = vects.Select(v => 
                new Vector3(v.x, transform.position.y, (v.x * a) + b)
            ).ToList();

        // 回帰直線を表示
        if (LineVects.Count > 0 && m_lineRenderer != null)
        {
            m_lineRenderer.positionCount = LineVects.Count;
            m_lineRenderer.SetPositions(LineVects.ToArray());
        }

    }

    protected override void Awake()
    {
        base.Awake();

        m_lineRenderer = this.GetComponent<LineRenderer>();

        Material mat = m_lineRenderer.material;
        mat.shader = LineShader;
        mat.color = Color.red;
    }

}
