using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class PlayerMoveCommandState : IBehaviourState
    {
        public string StateName => "Moving in Position";

        public void Update(GameObject gameObject, IActor actor)
        {
            actor.AIBase.canMove = true;       
        }
    }
}
