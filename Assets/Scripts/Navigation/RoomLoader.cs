using UnityEngine;

using HoloToolkit.Unity.SpatialMapping;

public class RoomLoader : MonoBehaviour
{
    public bool DrawMesh = false;
    public string FileName;
    public Material RenderMaterial;

    private bool m_prevDrawMesh;

    public void Start()
    {
        m_prevDrawMesh = DrawMesh;

        Load();
    }

    public bool Load()
    {
        bool errored = FileName == null;

        if (!errored)
        {
            try
            {
                var meshes = MeshSaver.Load(FileName);

                for (int iMesh = 0; iMesh < meshes.Count; iMesh++)
                {
                    var obj = new GameObject("mesh-" + iMesh);
                    obj.transform.SetParent(gameObject.transform);
                    obj.layer = SpatialMappingManager.Instance.PhysicsLayer;

                    var meshFilter = obj.AddComponent<MeshFilter>();
                    meshFilter.sharedMesh = meshes[iMesh];

                    var renderer = obj.AddComponent<MeshRenderer>();
                    renderer.sharedMaterial = RenderMaterial;
                    renderer.enabled = DrawMesh;

                    var collider = obj.AddComponent<MeshCollider>();
                    collider.sharedMesh = meshes[iMesh];
                }
            }
            catch (System.Exception)
            {
                errored = true;
            }

        }

        return !errored;
    }

    private void Update()
    {
        if (m_prevDrawMesh ^ DrawMesh)
        {
            m_prevDrawMesh = DrawMesh;

            foreach(var obj in gameObject.GetComponentsInChildren<MeshRenderer>())
            {
                obj.enabled = DrawMesh;
            }

        }

    }

}

