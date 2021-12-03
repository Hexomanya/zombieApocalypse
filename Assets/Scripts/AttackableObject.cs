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

        private ActorManagerBase actorManagerBase;
    
        void Start()
        {
            CurrentHealth = MaxHealth;
            actorManagerBase = transform.parent?.GetComponent<ActorManagerBase>();
        }

        void Update()
        {
            if (CurrentHealth <= 0f)
            {
                bloodManager?.StopDrop();
                if ((bloodManager != null && !bloodManager.IsBloodEffectPlaying() || bloodManager == null))
                {
                    Die();
                }
            }
        }

        private void Die()
        {
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
            if(actorManagerBase is HumanManager)
            {
                bloodManager.PlaySplatter(rotation);
                bloodManager.PlayDrop();
            }
        }
    }
}
