using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class FleeingState : IBehaviourState
    {
        public string StateName => "Fleeing";

        public void Update(GameObject gameObject, IActor actor)
        {
            // TODO: get nearest safe position from pathfinder 
            Vector3 direction = Vector3.up * 500f - gameObject.transform.position;
            direction = Utility.RemoveNumberFractions(direction, true);

            gameObject.transform.position += direction.normalized * Time.deltaTime * actor.MoveSpeed;
        }
    }
}
