using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class IdleState : IBehaviourState
    {
        public string StateName => "Idle";

        public void Update(GameObject gameObject, IActor actor)
        {
            actor.AIBase.canMove = false;
            actor.AIBase.destination = gameObject.transform.position;
        }
    }
}
