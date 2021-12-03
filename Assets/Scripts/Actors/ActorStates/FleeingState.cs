using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class FleeingState : IBehaviourState
    {
        public string StateName => "Fleeing";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actor.AstarAI.canMove = true;
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            actor.AstarAI.canMove = false;
            actor.AstarAI.SetPath(null);
        }

        public void Update(GameObject gameObject, IActor actor, IActorType actorType)
        {
            Vector3 closestBorder;
            closestBorder = GetClosestSafeMapBorder(gameObject, actor);

            // Actor reached MapBorder
            if (Vector3.Distance(closestBorder, gameObject.transform.position) < 1f)
            {
                actor.ActorManager.DeleteActor(gameObject);
            }
            else
            {
                actorType.UpdatePath(gameObject.transform.position, closestBorder, actor);
            }
        }

        private Vector3 GetClosestSafeMapBorder(GameObject gameObject, IActor actor)
        {
            Vector3 closestBorder;
            Vector3 dir = gameObject.transform.position - actor.DetectionHandler.GetTargetClusterCenter();
            dir = Utility.RemoveZAxis(dir);

            // TODO: humans sometimes run in dumb directions
            if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            {
                if (dir.x > 0)
                {
                    closestBorder = new Vector3(MapBorderProvider.Instance.MaxX, gameObject.transform.position.y, 0f);
                }
                else
                {
                    closestBorder = new Vector3(MapBorderProvider.Instance.MinX, gameObject.transform.position.y, 0f);
                }
            }
            else
            {
                if (dir.y > 0)
                {
                    closestBorder = new Vector3(gameObject.transform.position.x, MapBorderProvider.Instance.MaxY, 0f);
                }
                else
                {
                    closestBorder = new Vector3(gameObject.transform.position.x, MapBorderProvider.Instance.MinY, 0f);
                }
            }

            return closestBorder;
        }
    }
}
