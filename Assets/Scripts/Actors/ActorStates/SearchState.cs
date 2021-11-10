using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class SearchState : IBehaviourState
    {
        public string StateName => "Searching";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            if (actor.LastKnownTargetPosition != null)
            {
                actor.AIBase.destination = actor.LastKnownTargetPosition.position;
                actor.AIBase.canMove = true;
            }
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AIBase.canMove = false;
            actor.AIBase.destination = gameObject.transform.position;
        }

        public void Update(GameObject gameObject, IActor actor)
        {
            if (Utility.RemoveNumberFractions(actor.AIBase.destination - gameObject.transform.position, true).magnitude <= actor.AIBase.radius) 
            {
                actor.LastKnownTargetPosition = null;
            }
        }
    }
}
