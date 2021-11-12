using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class EngageState : IBehaviourState
    {
        public string StateName => "Engage";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actorType.UpdatePath(gameObject.transform.position, actor.DetectionHandler.GetClosestTargetWithLoS().transform.position, actor);
            actor.AstarAI.canMove = true;
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AstarAI.SetPath(null);
            actor.AstarAI.canMove = false;
        }

        public void Update(GameObject gameObject, IActor actor, IActorType actorType)
        {
            // only update PathFinder if target position has changed
            if(actor.DetectionHandler.GetAnyTargetWithLoS() != null)
            {
                Transform targetPos = actor.DetectionHandler.GetClosestTargetWithLoS().transform;
                actor.LastKnownTargetPosition = targetPos;
                actorType.UpdatePath(gameObject.transform.position, actor.DetectionHandler.GetClosestTargetWithLoS().transform.position, actor);
            }
        }
    }
}
