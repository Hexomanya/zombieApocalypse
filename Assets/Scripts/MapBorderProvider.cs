using UnityEngine;

public class MapBorderProvider : MonoBehaviour
{
    private static MapBorderProvider instance;

    public static MapBorderProvider Instance => instance;

    [field: SerializeField]
    public float MaxX { get; private set; }

    [field: SerializeField]
    public float MinX { get; private set; }

    [field: SerializeField]
    public float MaxY { get; private set; }

    [field: SerializeField]
    public float MinY { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
