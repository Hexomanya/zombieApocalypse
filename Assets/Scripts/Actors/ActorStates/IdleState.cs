using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class IdleState : IBehaviourState
    {
        public string StateName => "Idle";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actor.AstarAI.SetPath(null);
            actor.AstarAI.canMove = false;
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            // do nothing
        }

        public void Update(GameObject gameObject, IActor actor, IActorType actorType)
        {
            // do nothing
        }
    }
}
