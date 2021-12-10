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
                actorType.UpdatePath(gameObject.transform.position, actor.LastKnownTargetPosition.position, actor, true);
                actor.AstarAI.canMove = true;
                actor.Animator?.SetBool("Walking", true);
            }
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AstarAI.canMove = false;
            actor.AstarAI.SetPath(null);
            actor.Animator?.SetBool("Walking", false);
        }

        public void Update(GameObject gameObject, IActor actor, IActorType actorType)
        {
            if (actor.LastKnownTargetPosition != null)
            {
                actorType.UpdatePath(gameObject.transform.position, actor.LastKnownTargetPosition.position, actor);
            }            

            if (actor.AstarAI.reachedEndOfPath) 
            {
                actor.LastKnownTargetPosition = null;
            }
        }
    }
}
