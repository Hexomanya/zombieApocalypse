using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class MeleeHandler : MonoBehaviour
    {
        public float meleeDamage = 5f;
        public float attackCooldown = 2f;

        private float AttackTimer { get; set; } = 0f;
        private List<AttackableObject> possibleTargets = new List<AttackableObject>();

        void Start()
        {
        }

        void Update()
        {
            if(AttackTimer <= 0f && possibleTargets.Count > 0)
            {
                possibleTargets[0].ApplyDamage(meleeDamage);
                AttackTimer = attackCooldown;
            }

            if (AttackTimer > 0f)
            {
                AttackTimer -= Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            AttackableObject attackableObject = collision.GetComponent<AttackableObject>();
            if(!possibleTargets.Contains(attackableObject))
            {
                possibleTargets.Add(attackableObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            possibleTargets.Remove(collision.GetComponent<AttackableObject>());
        }
    }
}