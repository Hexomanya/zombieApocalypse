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
            actorType.UpdatePath(gameObject.transform.position, actor.PatrollRoute.GetWaypointPosition(actor.WaypointIndex), actor, true);
            actor.AstarAI.canMove = true;
            actor.Animator?.SetBool("Walking", true);
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AstarAI.canMove = false;
            actor.AstarAI.SetPath(null);
            actor.Animator?.SetBool("Walking", false);
        }

        public void Update(GameObject gameObject, IActor actor, IActorType actorType)
        {
            if (Vector3.Distance(gameObject.transform.position, actor.PatrollRoute.GetWaypointPosition(actor.WaypointIndex)) < 2f)
            {
                actor.WaypointIndex = actor.PatrollRoute.GetNextIndex(actor.WaypointIndex);
            }

            actorType.UpdatePath(gameObject.transform.position, actor.PatrollRoute.GetWaypointPosition(actor.WaypointIndex), actor);
        }
    }
}
