using UnityEngine;

public class DestructablePathfindingObject : MonoBehaviour
{

    [SerializeField] private bool testDestroyBool = false;

    private Bounds bounds;

    private void Start()
    {
        bounds = GetComponentInChildren<Collider2D>().bounds;
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
