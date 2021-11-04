using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class EngageState : IBehaviourState
    {
        public string StateName => "Engage";

        public void Update(GameObject gameObject, IActor actor)
        {
            actor.AIBase.canMove = true;
        }
    }
}
