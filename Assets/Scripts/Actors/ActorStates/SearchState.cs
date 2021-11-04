using Assets.Scripts.Actors.ActorTypes;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class SearchState : IBehaviourState
    {
        public string StateName => "Searching";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
        }

        public void Update(GameObject gameObject, IActor actor)
        {
            actor.AIBase.canMove = false;
            actor.AIBase.destination = gameObject.transform.position;
            // TODO: do something, examples:
            // - Actor could wander around for a bit
            // - Actor could walk towards last known enemy position
            // - Actor could walk towards friendly actors (though that might be similar to patrolling)
            // - Actor could partially walk towards closest enemy even if they are not in detection range
            return;

            // for now I will leave this as an Idle state due to low priority as well as requiering a proper pathfinder
        }
    }
}
