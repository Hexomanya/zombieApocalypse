using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructablePathfindingObject : MonoBehaviour
{

    [SerializeField] private bool testDestroyBool = false;

    Bounds bounds;

    private void Start()
    {
        bounds = this.GetComponent<Collider2D>().bounds;
    }

    private void Update()
    {
        if (testDestroyBool)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (bounds != null && AstarPath.active != null)
        {
            AstarPath.active.UpdateGraphs(bounds);
        }
    }
}
