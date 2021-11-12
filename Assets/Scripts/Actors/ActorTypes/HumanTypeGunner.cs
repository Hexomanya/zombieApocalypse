using Assets.Scripts.Actors.ActorStates;
using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorTypes
{
    public class HumanTypeGunner : ActorTypeBase
    {
        public override void DecideOnNextState(GameObject gameObject, IActor actor)
        {
            switch (currentState)
            {
                case IdleState _:
                    HandleIdleState(gameObject, actor);
                    break;
                case ShootingState _:
                    HandleShootingState(gameObject, actor);
                    break;
                case MeleeState _:
                    HandleMeleeState(gameObject, actor);
                    break;
                case SearchState _:
                    HandleSearchingState(gameObject, actor);
                    break;
                case ReturningState _:
                    HandleReturningState(gameObject, actor);
                    break;
            }
        }

        private void HandleReturningState(GameObject gameObject, IActor actor)
        {
            if (actor.AstarAI.reachedEndOfPath)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Idle);
            }
        }

        private void HandleMeleeState(GameObject gameObject, IActor actor)
        {
            if (actor.MeleeRangeHandler.GetPossibleTarget() == null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Idle);
            }
        }

        private void HandleSearchingState(GameObject gameObject, IActor actor)
        {
            if (actor.MeleeRangeHandler.GetPossibleTarget() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Melee);
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Shooting);
            }
            else if (actor.LastKnownTargetPosition == null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Returning);
            }
        }

        private void HandleShootingState(GameObject gameObject, IActor actor)
        {
            if (actor.MeleeRangeHandler.GetPossibleTarget() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Melee);
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() == null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Idle);
            }
        }

        private void HandleIdleState(GameObject gameObject, IActor actor)
        {
            if (actor.DetectionHandler.GetAnyTargetWithLoS() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Shooting);
            }
            else if (actor.LastKnownTargetPosition != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Searching);
            }
        }
    }
}
