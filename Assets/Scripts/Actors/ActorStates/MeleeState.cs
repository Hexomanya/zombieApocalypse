using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class MeleeState : IBehaviourState
    {
        public string StateName => "Melee";

        public void Update(GameObject gameObject, IActor actor)
        {
            if (actor.AttackTimer <= 0f && actor.CurrentMeleeTarget != null)
            {
                actor.CurrentMeleeTarget.ApplyDamage(actor.MeleeDamage);
                actor.AttackTimer = actor.AttackCooldown;
            }

            if (actor.AttackTimer > 0f)
            {
                actor.AttackTimer -= Time.deltaTime;
            }
        }
    }
}
