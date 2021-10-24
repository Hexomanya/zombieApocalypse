using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class PlayerMoveCommandState : IBehaviourState
    {
        public string StateName => "Moving in Position";

        public void Update(GameObject gameObject, IActor actor)
        {
            Vector3 direction = actor.CurrentMoveTarget - gameObject.transform.position;
            direction = Utility.RemoveNumberFractions(direction, true);

            // TODO: Get Path from pathfinder
            gameObject.transform.position += direction.normalized * Time.deltaTime * actor.MoveSpeed;        
        }
    }
}
