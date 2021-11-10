using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class MeleeState : IBehaviourState
    {
        public string StateName => "Melee";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actor.AIBase.canMove = false;
            actor.AIBase.destination = gameObject.transform.position;
            actor.MeleeAttackTimer = actor.MeleeAttackCooldown;
            actor.CurrentMeleeTarget = actor.MeleeRangeHandler.GetPossibleTarget();
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.CurrentMeleeTarget = null;
            actor.MeleeAttackTimer = actor.MeleeAttackCooldown;
        }

        public void Update(GameObject gameObject, IActor actor)
        {
            if (actor.MeleeAttackTimer <= 0f && actor.CurrentMeleeTarget != null)
            {
                actor.CurrentMeleeTarget.ApplyDamage(actor.MeleeDamage);
                actor.MeleeAttackTimer = actor.MeleeAttackCooldown;
            }

            if (actor.MeleeAttackTimer > 0f)
            {
                actor.MeleeAttackTimer -= Time.deltaTime;
            }
        }
    }
}
