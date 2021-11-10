using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class PatrollingState : IBehaviourState
    {
        public string StateName => "Patrolling";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actor.WaypointIndex = actor.PatrollRoute.GetIndexOfClosestWaypoint(gameObject.transform.position);
            actor.AstarAI.destination = actor.PatrollRoute.GetWaypointPosition(actor.WaypointIndex);
            actor.AstarAI.canMove = true;
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AstarAI.canMove = false;
            actor.AstarAI.destination = gameObject.transform.position;
        }

        public void Update(GameObject gameObject, IActor actor)
        {
            if (Vector3.Distance(gameObject.transform.position, actor.AstarAI.destination) <= actor.AstarAI.radius * 2f) // increase actor radius to compensate position inaccuracies
            {
                actor.WaypointIndex = actor.PatrollRoute.GetNextIndex(actor.WaypointIndex);
                actor.AstarAI.destination = actor.PatrollRoute.GetWaypointPosition(actor.WaypointIndex);
            }
        }
    }
}
