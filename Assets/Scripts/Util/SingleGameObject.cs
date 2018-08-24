using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloToolkit.Unity;

public class SingleGameObject : MonoBehaviour
{
    private static List<GameObject> instances = new List<GameObject>();

    public GameObject GetInstance(string _name)
    {
        return instances.First(x => x.name == _name);
    }

    private void Awake()
    {
        if (instances.Count != 0)
        {
            if (instances.Count(x => x.name == this.name) >= 1)
            {
                Debug.LogErrorFormat("Trying to instantiate a second instance of SingleGameObject {0}. Additional Instance was destroyed", this.name);

                if (Application.isEditor)
                {
                    DestroyImmediate(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }

                return;
            }
        }

        gameObject.GetParentRoot().DontDestroyOnLoad();

        instances.Add(gameObject);
    }

    private void OnDestroy()
    {
        instances.RemoveAll(x => x.name == this.name);
    }
}
