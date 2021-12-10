using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class ReturningState : IBehaviourState
    {
        public string StateName => "Returning";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actorType.UpdatePath(gameObject.transform.position, actor.SpawnPos, actor, true);
            actor.AstarAI.canMove = true;
            actor.Animator?.SetBool("Walking", true);
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AstarAI.SetPath(null);
            actor.AstarAI.canMove = false;
            actor.Animator?.SetBool("Walking", false);
        }

        public void Update(GameObject gameObject, IActor actor, IActorType actorType)
        {
        }
    }
}
