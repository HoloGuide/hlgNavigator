using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainIconScale : MonoBehaviour {

    [SerializeField] private GameObject IconMask;
    [SerializeField] private GameObject targetIcon;
    [SerializeField] private float xsmall;
    [SerializeField] private float xbig;

    void Update()
    {
        if (IconMask.transform.localPosition.x <= xbig && IconMask.transform.localPosition.x >= xsmall)
        {
            targetIcon.transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
        }
        else
        {
            targetIcon.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
