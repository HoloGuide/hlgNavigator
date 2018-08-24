using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rayを打ち、壁の座標を取得する
/// </summary>
public class MultiRayCast : MonoBehaviour
{
    public LayerMask lm;
    [Range(1, 100)] public int RayCount = 10;
    [Range(1, 100)] public float Depth = 5;
    [Range(1, 100)] public float Width = 10;

    private void Update()
    {
        // Rayを打つ
        float hw = Width / 2;
        float inte = Width / RayCount;
        var vects = new List<Vector3>();

        for (float i = -hw; i <= hw; i += inte)
        {
            var vect = new Vector3(i, 0, Depth);
            RaycastHit rh;

            if (Physics.Raycast(transform.position, (transform.rotation * vect).normalized, out rh, 100, lm.value, QueryTriggerInteraction.Ignore))
            {
                Debug.DrawLine(transform.position, rh.point, Color.blue);
                // 壁との交点をvectsに追加
                vects.Add(rh.point);
            }
            else
            {
                Debug.DrawRay(transform.position, (transform.rotation * vect).normalized * 10, Color.blue);
            }
        }

        // 回帰直線を計算し、表示
        AVGLine.Instance.Calculate(vects);
    }
}
