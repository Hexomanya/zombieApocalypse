using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class EngageState : IBehaviourState
    {
        public string StateName => "Engage";

        public void Update(GameObject gameObject, IActor actor)
        {
            // TODO: Get Path from pathfinder
            Vector3 direction = actor.CurrentMoveTarget - gameObject.transform.position;
            direction = Utility.RemoveNumberFractions(direction, true);

            gameObject.transform.position += direction.normalized * Time.deltaTime * actor.MoveSpeed;
        }
    }
}
