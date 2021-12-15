using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class PlayerMoveCommandState : IBehaviourState
    {
        public string StateName => "Moving to Position";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            Vector3 destination = Utility.RemoveZAxis(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            actorType.UpdatePath(gameObject.transform.position, destination, actor, true);
            actor.ConcentrationTimer = actor.ConcentrationTime;
            actorType.PlayerCommandCooldownTimer = actor.PlayerCommandCooldown;
            actor.AstarAI.canMove = true;
            actor.Animator?.SetBool("Walking", true);

            PlayerClickVisualizer.Instance.MarkNewPosition(gameObject, destination);
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AstarAI.SetPath(null);
            actor.AstarAI.canMove = false;
            actor.Animator?.SetBool("Walking", false);

            PlayerClickVisualizer.Instance.RemoveZombie(gameObject);
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
