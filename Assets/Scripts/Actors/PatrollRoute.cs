using UnityEngine;

namespace Assets.Scripts.Actors
{
    public enum RouteType
    {
        Reverse, Circle
    }

    public class PatrollRoute : MonoBehaviour
    {
        [SerializeField]
        private Transform[] waypoints;

        [SerializeField, Tooltip("Sets behaviour when reaching last Waypoint. \nReverse: Actor will return the same route backwards. \nCircle: Actor will continue to first Waypoint")]
        private RouteType routeType = RouteType.Circle;

        [field: SerializeField]
        public bool DrawPathInEditor { get; private set; } = false;

        public Color DrawColor = Color.blue;

        private bool reverse = false;

        private void OnDrawGizmos()
        {
            if (!DrawPathInEditor)
            {
                return;
            }

            Gizmos.color = DrawColor;
            for (int i = 1; i < waypoints.Length; i++)
            {
                Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
            }

            if (routeType == RouteType.Circle)
            {
                Gizmos.DrawLine(waypoints[0].position, waypoints[waypoints.Length - 1].position);
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
                if (indexClosest == i)
                {
                    continue;
                }

                if (Vector3.Distance(waypoints[i].position, pos) < Vector3.Distance(waypoints[indexClosest].position, pos))
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
            if (routeType == RouteType.Circle)
            {
                return (oldIndex + 1) % waypoints.Length;
            }

            if(reverse)
            {
                if (oldIndex == 0)
                {
                    reverse = false;
                    return oldIndex + 1;
                }

                return oldIndex - 1;
            }
            else
            {
                if (oldIndex + 1 == waypoints.Length)
                {
                    reverse = true;
                    return oldIndex - 1;
                }

                return oldIndex + 1;
            }
        }
    }
}