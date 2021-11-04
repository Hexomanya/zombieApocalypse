using Assets.Scripts.Actors.ActorTypes;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class PlayerMoveCommandState : IBehaviourState
    {
        public string StateName => "Moving in Position";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actor.AIBase.destination = Utility.RemoveZAxis(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            actor.ConcentrationTimer = actor.ConcentrationTime;
            actorType.PlayerCommandCooldownTimer = actor.PlayerCommandCooldown;
            actor.AIBase.canMove = true;
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AIBase.destination = gameObject.transform.position;
            actor.AIBase.canMove = false;
        }

        public void Update(GameObject gameObject, IActor actor)
        {
            // movement is handled by AIBase of PathFinder
        }
    }
}
