using Assets.Scripts.Actors.ActorStates;
using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorTypes
{
    public class HumanTypePatrolling : ActorTypeBase
    {
        public override void DecideOnNextState(GameObject gameObject, IActor actor)
        {
            switch (currentState)
            {
                case IdleState _:
                    HandleIdleState(gameObject, actor);
                    break;
                case EngageState _:
                    HandleEngagingState(gameObject, actor);
                    break;
                case MeleeState _:
                    HandleMeleeState(gameObject, actor);
                    break;
                case SearchState _:
                    HandleSearchingState(gameObject, actor);
                    break;
                case PatrollingState _:
                    HandlePatrollingState(gameObject, actor);
                    break;
            }
        }

        private void HandlePatrollingState(GameObject gameObject, IActor actor)
        {
            if (actor.DetectionHandler.GetAnyTargetWithLoS() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Engaging);
            }
            else if (actor.LastKnownTargetPosition != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Searching);
            }
        }

        private void HandleMeleeState(GameObject gameObject, IActor actor)
        {
            if (actor.MeleeRangeHandler.GetPossibleTarget() == null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Searching);
            }
        }

        private void HandleSearchingState(GameObject gameObject, IActor actor)
        {
            if (actor.DetectionHandler.GetAnyTargetWithLoS() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Engaging);
            }
            else if (actor.LastKnownTargetPosition == null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Idle);
            }
        }

        private void HandleEngagingState(GameObject gameObject, IActor actor)
        {
            if (actor.MeleeRangeHandler.GetPossibleTarget() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Melee);
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() == null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Searching);
            }
        }

        private void HandleIdleState(GameObject gameObject, IActor actor)
        {
            if (actor.DetectionHandler.GetAnyTargetWithLoS() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Engaging);
            }
            else if (actor.LastKnownTargetPosition != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Searching);
            }
            else
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Patrolling);
            }
        }
    }
}
