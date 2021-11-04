using Assets.Scripts.Actors.ActorTypes;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class EngageState : IBehaviourState
    {
        public string StateName => "Engage";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actor.AIBase.destination = actor.DetectionHandler.GetClosestTargetWithLoS().transform.position;
            actor.AIBase.canMove = true;
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AIBase.destination = gameObject.transform.position;
            actor.AIBase.canMove = false;
        }

        public void Update(GameObject gameObject, IActor actor)
        {
            // only update PathFinder if target position has changed
            if(actor.DetectionHandler.GetAnyTargetWithLoS() != null)
            {
                Transform targetPos = actor.DetectionHandler.GetClosestTargetWithLoS().transform;
                actor.LastKnownTargetPosition = targetPos;
                if (actor.AIBase.destination != targetPos.position)
                {
                    actor.AIBase.destination = targetPos.position;
                }
            }
        }
    }
}
