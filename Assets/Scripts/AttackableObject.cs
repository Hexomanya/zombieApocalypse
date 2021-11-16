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
            // TODO: Do something
            ZombieManager actorManager = transform.parent?.GetComponent<ZombieManager>();
            if (actorManager == null)
            {
                Destroy(gameObject);
            }
            else
            {
                actorManager.DeleteActor(gameObject);
            }
        }

        public void ApplyDamage(float damage)
        {
            CurrentHealth -= damage;
        }
    }
}
