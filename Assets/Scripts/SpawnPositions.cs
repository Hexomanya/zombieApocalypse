using UnityEngine;

public class SpawnPositions : MonoBehaviour
{
    public static SpawnPositions Instance { get; private set; }

    public Transform[] Positions { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More then one Horde instance has been found!");
            return;
        }

        Instance = this;
        Positions = new Transform[transform.childCount];
        for (int i = 0; i < Positions.Length; i++)
        {
            Positions[i] = transform.GetChild(i);
        }
    }
}
