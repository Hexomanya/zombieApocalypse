using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class ReturningState : IBehaviourState
    {
        public string StateName => "Returning";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actor.AstarAI.destination = actor.SpawnPos;
            actor.AstarAI.canMove = true;
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AstarAI.destination = gameObject.transform.position;
            actor.AstarAI.canMove = false;
        }

        public void Update(GameObject gameObject, IActor actor)
        {
        }
    }
}
