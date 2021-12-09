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

            SoundEffectManager.Instance.PlaySound(SoundEffectManager.SoundEffect.PanickedScream, actor.AudioSource);
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
            
            if (actor.DetectionHandler.IsAnyTargetInRange())
            {
                return RunAwayFromZombies(gameObject, actor);
            }

            return CalcClosestMapBorder(gameObject, actor);
        }

        private Vector3 CalcClosestMapBorder(GameObject gameObject, IActor actor)
        {
            Vector3 closestBorder = new Vector3(MapBorderProvider.Instance.MaxX, gameObject.transform.position.y, 0f);
            float dist = Vector3.Distance(gameObject.transform.position,closestBorder);
            
            if (Vector3.Distance(gameObject.transform.position,
                new Vector3(MapBorderProvider.Instance.MinX, gameObject.transform.position.y, 0f)) < dist)
            {
                closestBorder = new Vector3(MapBorderProvider.Instance.MinX, gameObject.transform.position.y, 0f);
                dist = Vector3.Distance(gameObject.transform.position, closestBorder);
            }

            if (Vector3.Distance(gameObject.transform.position,
                new Vector3(gameObject.transform.position.x, MapBorderProvider.Instance.MaxY, 0f)) < dist)
            {
                closestBorder = new Vector3(gameObject.transform.position.x, MapBorderProvider.Instance.MaxY, 0f);
                dist = Vector3.Distance(gameObject.transform.position, closestBorder);
            }
            
            if (Vector3.Distance(gameObject.transform.position,
                new Vector3(gameObject.transform.position.x, MapBorderProvider.Instance.MinY, 0f)) < dist)
            {
                closestBorder = new Vector3(gameObject.transform.position.x, MapBorderProvider.Instance.MinY, 0f);
            }

            return closestBorder;
        }

        private Vector3 RunAwayFromZombies(GameObject gameObject, IActor actor)
        {
            Vector3 closestBorder;
            Vector3 zombiesDir = gameObject.transform.position - actor.DetectionHandler.GetTargetClusterCenter();
            zombiesDir = Utility.RemoveZAxis(zombiesDir);

            if (Mathf.Abs(zombiesDir.x) > Mathf.Abs(zombiesDir.y))
            {
                if (zombiesDir.x > 0)
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
                if (zombiesDir.y > 0)
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
