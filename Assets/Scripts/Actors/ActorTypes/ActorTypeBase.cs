using Assets.Scripts.Actors.ActorStates;
using Assets.Scripts.Actors.Interfaces;
using Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorTypes
{
    public abstract class ActorTypeBase : IActorType
    {
        protected IBehaviourState currentState = BehaviourStateProvider.Idle;

        public IBehaviourState CurrentState => currentState;

        public float PlayerCommandCooldownTimer { get; set; }

        public ABPath Path { get; private set; }

        public abstract void DecideOnNextState(GameObject gameObject, IActor actor);

        public void UpdatePath(Vector3 currentPos, Vector3 destination, IActor actor)
        {
            Path = ABPath.Construct(currentPos, destination);
            Path.traversalProvider = new BlockManager.TraversalProvider(actor.BlockManager, BlockManager.BlockMode.OnlySelector, actor.ActorManager.GetNodeBlockers(actor.NodeBlocker));
            AstarPath.StartPath(Path);
            Path.BlockUntilCalculated();
            if (!Path.error)
            {
                actor.DeativatePathBlocking = false;
                actor.AstarAI.SetPath(Path);
                // Draw the path in the scene view
                for (int i = 0; i < Path.vectorPath.Count - 1; i++)
                {
                    Debug.DrawLine(Path.vectorPath[i], Path.vectorPath[i + 1], Color.green);
                }
            }
            else
            {
                actor.DeativatePathBlocking = true;
            }
        }

        protected void SwitchState(GameObject gameObject, IActor actor, IBehaviourState nextState)
        {
            currentState.ExitState(gameObject, actor);
            currentState = nextState;
            currentState.EnterState(gameObject, actor, this);
        }
    }
}
