using Assets.Scripts.Actors.ActorTypes;
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
            actor.AttackTimer = actor.AttackCooldown;
            actor.CurrentMeleeTarget = actor.MeleeRangeHandler.GetPossibleTarget();
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.CurrentMeleeTarget = null;
            actor.AttackTimer = actor.AttackCooldown;
        }

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
