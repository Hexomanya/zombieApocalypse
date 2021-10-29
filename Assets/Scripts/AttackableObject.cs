using UnityEngine;

namespace Assets.Scripts
{
    public class AttackableObject : MonoBehaviour
    {
        [field: SerializeField]
        public float MaxHealth { get; private set; } = 20f;

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
            Destroy(gameObject);
        }

        public void ApplyDamage(float damage)
        {
            CurrentHealth -= damage;
        }
    }
}
