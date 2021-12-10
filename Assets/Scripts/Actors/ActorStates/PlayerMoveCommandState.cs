using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class PlayerMoveCommandState : IBehaviourState
    {
        public string StateName => "Moving to Position";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actorType.UpdatePath(gameObject.transform.position, Utility.RemoveZAxis(Camera.main.ScreenToWorldPoint(Input.mousePosition)), actor, true);
            actor.ConcentrationTimer = actor.ConcentrationTime;
            actorType.PlayerCommandCooldownTimer = actor.PlayerCommandCooldown;
            actor.AstarAI.canMove = true;
            actor.Animator?.SetBool("Walking", true);
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AstarAI.SetPath(null);
            actor.AstarAI.canMove = false;
            actor.Animator?.SetBool("Walking", false);
        }

        public void Update(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actorType.UpdatePath(gameObject.transform.position, actorType.Path.endPoint, actor);

            if (actor.ConcentrationTime > 0)
            {
                SoundEffectManager.Instance.PlayZombieGrowl(actor.AudioSource);
            }
        }
    }
}
