using Assets.Scripts.Actors;
using UnityEngine;

namespace Assets.Scripts
{
    public class AttackableObject : MonoBehaviour
    {
        [field: SerializeField]
        public float MaxHealth { get; set; } = 20f;

        public float CurrentHealth { get; private set; }

        public BloodManager bloodManager;

        public GameObject Visuals = null;

        private ActorManagerBase actorManagerBase;

        private bool dead = false;
    
        void Start()
        {
            CurrentHealth = MaxHealth;
            actorManagerBase = transform.parent?.GetComponent<ActorManagerBase>();
        }

        void Update()
        {
            if (CurrentHealth <= 0f && !dead)
            {
                bloodManager?.StopDrop();
                Visuals?.SetActive(false);
                Die();
            }
        }

        private void Die()
        {
            dead = true;
            if (actorManagerBase == null)
            {
                Destroy(gameObject);
            }
            else
            {
                actorManagerBase.ActorDied(gameObject);
            }
        }

        public void ApplyDamage(float damage, Quaternion rotation)
        {
            CurrentHealth -= damage;
            if(bloodManager != null)
            {
                bloodManager.PlaySplatter(rotation);
                bloodManager.PlayDrop();
            }
        }
    }
}
