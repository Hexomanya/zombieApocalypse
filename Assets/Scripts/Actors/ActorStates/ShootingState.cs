using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class ShootingState : IBehaviourState
    {
        public string StateName => "Shooting";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actor.AstarAI.canMove = false;
            actor.AstarAI.SetPath(null);
            actor.RangeAttackHandler.RangedAttackTimer = actor.RangeAttackHandler.RangedAttackCooldown;
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.RangeAttackHandler.RangedAttackTimer = actor.RangeAttackHandler.RangedAttackCooldown;
        }

        public void Update(GameObject gameObject, IActor actor, IActorType actorType)
        {
            AttackableObject attackableObject = actor.DetectionHandler.GetAnyTargetWithLoS();
            if (attackableObject != null)
            {
                if (actor.RangeAttackHandler.RangedAttackTimer <= 0f)
                {
                    actor.RangeAttackHandler.Shoot((attackableObject.gameObject.transform.position - gameObject.transform.position).normalized);
                    actor.RangeAttackHandler.RangedAttackTimer = actor.RangeAttackHandler.RangedAttackCooldown;

                    SoundEffectManager.Instance.PlaySound(SoundEffectManager.SoundEffect.PistolShot, actor.AudioSource);
                }

                actor.LastKnownTargetPosition = attackableObject.transform;
            }

            if (actor.RangeAttackHandler.RangedAttackTimer > 0f)
            {
                actor.RangeAttackHandler.RangedAttackTimer -= Time.deltaTime;
            }
        }
    }
}
