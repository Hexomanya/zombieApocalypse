using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class ReturningState : IBehaviourState
    {
        public string StateName => "Returning";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actor.AIBase.destination = actor.SpawnPos;
            actor.AIBase.canMove = true;
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AIBase.destination = gameObject.transform.position;
            actor.AIBase.canMove = false;
        }

        public void Update(GameObject gameObject, IActor actor)
        {
        }
    }
}
