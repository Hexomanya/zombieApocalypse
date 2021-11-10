using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class DetectionHandler : MonoBehaviour
    {
        public float detectionRange = 5f;
        public LayerMask obstacleLayer = 0;
    
        private List<AttackableObject> possibleTargets = new List<AttackableObject>();
    
        void Start()
        {
            gameObject.GetComponent<CircleCollider2D>().radius = detectionRange;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            AttackableObject attackableObject = collision.GetComponent<AttackableObject>();
            if (attackableObject == null)
            {
                throw new System.ArgumentNullException($"Object '{collision.gameObject.name}' is missing an 'AttackableObject' Script!");
            }

            if (!possibleTargets.Contains(attackableObject))
            {
                possibleTargets.Add(attackableObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            possibleTargets.Remove(collision.GetComponent<AttackableObject>());
        }

        public bool IsAnyTargetInRange()
        {
            return possibleTargets.Count > 0;
        }
    
        // LoS - Line of Sight
        public AttackableObject GetAnyTargetWithLoS()
        {
            if (possibleTargets.Count > 0)
            {
                foreach (AttackableObject target in possibleTargets)
                {
                    Vector3 distance = transform.position - target.transform.position;
                    RaycastHit2D[] hits = Physics2D.RaycastAll(target.transform.position, distance.normalized, distance.magnitude, obstacleLayer);

                    if (hits.Length == 0)
                    {
                        return target;
                    }
                }
            }

            return null;
        }

        public AttackableObject GetClosestTargetWithLoS()
        {
            AttackableObject closest = null;
            Vector3 dis = Vector3.one * 500f;

            if (possibleTargets.Count > 0)
            {
                foreach (AttackableObject target in possibleTargets)
                {
                    Vector3 distance = transform.position - target.transform.position;
                    RaycastHit2D[] hits = Physics2D.RaycastAll(target.transform.position, distance.normalized, distance.magnitude, obstacleLayer);
                    Debug.DrawLine(target.transform.position, target.transform.position + distance, Color.red);

                    if (hits.Length == 0)
                    {
                        if (distance.magnitude < dis.magnitude)
                        {
                            dis = distance;
                            closest = target;
                        }
                    }
                }
            }
        
            return closest;
        }

        public Vector3 GetTargetClusterCenter()
        {
            Vector3 center = Vector3.zero;

            if (possibleTargets.Count > 0)
            {
                foreach (AttackableObject item in possibleTargets)
                {
                    center += item.transform.position;
                }

                return center / possibleTargets.Count;
            }

            return transform.position;
        }
    }
}
