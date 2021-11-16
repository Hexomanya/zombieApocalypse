using Assets.Scripts.Actors;
using UnityEngine;

namespace Assets.Scripts
{
    public class AttackableObject : MonoBehaviour
    {
        [field: SerializeField]
        public float MaxHealth { get; set; } = 20f;

        public float CurrentHealth { get; private set; }
    
        void Start()
        {
            CurrentHealth = MaxHealth;
        }

        void Update()
        {
            if (CurrentHealth <= 0f)
            {
                Die();
            }
        }

        private void Die()
        {
            ActorManagerBase actorManager = transform.parent?.GetComponent<ActorManagerBase>();
            if (actorManager == null)
            {
                Destroy(gameObject);
            }
            else
            {
                actorManager.ActorDied(gameObject);
            }
        }

        public void ApplyDamage(float damage)
        {
            CurrentHealth -= damage;
        }
    }
}
