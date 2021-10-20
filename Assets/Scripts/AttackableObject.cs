using UnityEngine;

namespace Assets.Scripts
{
    public class AttackableObject : MonoBehaviour
    {
        public float maxHealth = 20f;
        private float CurrentHealth { get; set; }
    
        void Start()
        {
            CurrentHealth = maxHealth;
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
