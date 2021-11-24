using Assets.Scripts.Actors.ActorStates;
using Assets.Scripts.Actors.Interfaces;
using Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorTypes
{
    public abstract class ActorTypeBase : IActorType
    {
        private float pathUpdateTimer = 0f;

        protected IBehaviourState currentState = BehaviourStateProvider.Idle;

        public IBehaviourState CurrentState => currentState;

        public float PlayerCommandCooldownTimer { get; set; }

        public ABPath Path { get; private set; }

        public abstract void DecideOnNextState(GameObject gameObject, IActor actor);

        public void UpdatePath(Vector3 currentPos, Vector3 destination, IActor actor, bool forceCall = false, bool ignorePathBlocking = false)
        {
            if(Path != null)
            {
                for (int i = 0; i < Path.vectorPath.Count - 1; i++)
                {
                    Debug.DrawLine(Path.vectorPath[i], Path.vectorPath[i + 1], Color.green);
                }
            }

            if (pathUpdateTimer > 0f && !forceCall)
            {
                pathUpdateTimer -= Time.deltaTime;
                return;
            }

            Path = ABPath.Construct(currentPos, destination);
            if (!ignorePathBlocking)
            {
                Path.traversalProvider = new BlockManager.TraversalProvider(actor.BlockManager, BlockManager.BlockMode.OnlySelector, actor.ActorManager.GetNodeBlockers(actor.NodeBlocker));
            }
            
            AstarPath.StartPath(Path);
            Path.BlockUntilCalculated();
            if (!Path.error)
            {
                actor.DeativatePathBlocking = false;
                actor.AstarAI.SetPath(Path);
            }
            else
            {
                actor.DeativatePathBlocking = true;
                actor.DetectionHandler.gameObject.transform.parent.position += new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), 0f);
            }

            pathUpdateTimer = 0.1f * Vector3.Distance(Path.startPoint, Path.endPoint);
        }

        protected void SwitchState(GameObject gameObject, IActor actor, IBehaviourState nextState)
        {
            currentState.ExitState(gameObject, actor);
            currentState = nextState;
            currentState.EnterState(gameObject, actor, this);
        }
    }
}
