using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class MeleeRangeHandler : MonoBehaviour
    {
        public float meleeDamage = 5f;
        public float attackCooldown = 2f;
        public float meleeRange = 0.7f;

        private List<AttackableObject> possibleTargets = new List<AttackableObject>();

        private void Start()
        {
            gameObject.GetComponent<CircleCollider2D>().radius = meleeRange;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            AttackableObject attackableObject = collision.transform.parent.GetComponent<AttackableObject>();
            if(!possibleTargets.Contains(attackableObject))
            {
                possibleTargets.Add(attackableObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            possibleTargets.Remove(collision.transform.parent.GetComponent<AttackableObject>());
        }

        public AttackableObject GetPossibleTarget()
        {
            // TODO: improve target selection
            if(possibleTargets.Count > 0)
            {
                return possibleTargets[0];
            }

            return null;
        }
    }
}