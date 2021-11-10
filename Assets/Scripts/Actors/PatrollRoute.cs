using UnityEngine;

public class PatrollRoute : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [field: SerializeField]
    public bool DrawPathInEditor { get; private set; } = false;

    private void OnDrawGizmos()
    {
        if(!DrawPathInEditor)
        {
            return;
        }

        Gizmos.color = Color.blue;
        for (int i = 1; i < waypoints.Length; i++)
        {
            Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);   
        }

        for (int i = 0; i < waypoints.Length; i++)
        {
            Gizmos.DrawSphere(waypoints[i].position, 0.3f);
        }
    }

    public int GetIndexOfClosestWaypoint(Vector3 pos)
    {
        int indexClosest = 0;
        
        for (int i = 0; i < waypoints.Length; i++)
        {
            if(indexClosest == i)
            {
                continue;
            }
            
            if(Vector3.Distance(waypoints[i].position, pos) < Vector3.Distance(waypoints[indexClosest].position, pos))
            {
                indexClosest = i;
            }
        }

        return indexClosest;
    }

    public Vector3 GetWaypointPosition(int index)
    {
        return waypoints[index].position;
    }

    public int GetNextIndex(int oldIndex)
    {
        return (oldIndex + 1) % waypoints.Length;
    }
}
