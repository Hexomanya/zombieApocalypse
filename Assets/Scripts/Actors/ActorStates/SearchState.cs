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
                actor.AstarAI.destination = actor.LastKnownTargetPosition.position;
                actor.AstarAI.canMove = true;
            }
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AstarAI.canMove = false;
            actor.AstarAI.destination = gameObject.transform.position;
        }

        public void Update(GameObject gameObject, IActor actor)
        {
            if (actor.AstarAI.reachedDestination) 
            {
                actor.LastKnownTargetPosition = null;
            }
        }
    }
}
