using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public AVGLine RegressionLine;

    private void Start()
    {
        var hololensCamera = GameObject.Find("HoloLensCamera");
        var component = hololensCamera.AddComponent<MultiRayCast>();
        component.lm = ~(1 << 5); // UI
    }

    void Update()
    {

    }
}
