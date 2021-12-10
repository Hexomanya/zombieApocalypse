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

        [SerializeField] private LayerMask doorLayerMask;

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
                GetComponentInChildren<Animator>()?.SetTrigger("Dead");
                bloodManager?.StopDrop();
                Destroy(Visuals);
                Die();
            }
        }

        private void Die()
        {
            dead = true;

            if (actorManagerBase == null)
            {
                //If Layermask not set, the mask is nothing
                if (doorLayerMask.value == (doorLayerMask | (1 << gameObject.layer)))
                {
                    //TODO Fix: SoundEffectManager.Instance.PlaySound(SoundEffectManager.SoundEffect.DoorBreaking, gameObject.GetComponent<AudioSource>());
                    SoundEffectManager.Instance.PlaySound(SoundEffectManager.SoundEffect.DoorBreaking, gameObject.transform.position);
                }
                
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
