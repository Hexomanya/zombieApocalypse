using Assets.Scripts.Actors.ActorStates;
using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorTypes
{
    public class HumanTypeFleeing : IActorType
    {
        private IBehaviourState currentState = BehaviourStateProvider.Idle;

        public IBehaviourState CurrentState => currentState;

        public float PlayerCommandCooldownTimer { get; set; }

        public void DecideOnNextState(GameObject gameObject, IActor actor)
        {
            switch (currentState)
            {
                case IdleState _:
                    HandleIdleState(gameObject, actor);
                    break;
                case FleeingState _:
                    HandleFleeingState(gameObject, actor);
                    break;
                case MeleeState _:
                    HandleMeleeState(gameObject, actor);
                    break;
            }
        }

        private void HandleMeleeState(GameObject gameObject, IActor actor)
        {
            if (actor.DetectionHandler.GetAnyTargetWithLoS() == null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Idle);
            }
            else if (actor.MeleeRangeHandler.GetPossibleTarget() == null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Fleeing);
            }
        }

        private void HandleFleeingState(GameObject gameObject, IActor actor)
        {
            // TODO: Implement "Got away"
            if (false)
            {
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() == null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Idle);
            }
            else if (actor.MeleeRangeHandler.GetPossibleTarget() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Melee);
            }
        }

        private void HandleIdleState(GameObject gameObject, IActor actor)
        {
            if (actor.MeleeRangeHandler.GetPossibleTarget() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Melee);
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Fleeing);
            }
        }

        private void SwitchState(GameObject gameObject, IActor actor, IBehaviourState nextState)
        {
            currentState.ExitState(gameObject, actor);
            currentState = nextState;
            currentState.EnterState(gameObject, actor, this);
        }
    }
}
