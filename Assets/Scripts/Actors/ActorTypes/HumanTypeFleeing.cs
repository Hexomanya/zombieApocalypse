using Assets.Scripts.Actors.ActorStates;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorTypes
{
    public class HumanTypeFleeing : IActorType
    {
        private IBehaviourState currentState = BehaviourStateProvider.Idle;

        public IBehaviourState CurrentState => currentState;

        public void DecideOnNextState(GameObject gameObject, IActor actor)
        {
            actor.CurrentMeleeTarget = actor.MeleeRangeHandler.GetPossibleTarget();
            switch (currentState)
            {
                case IdleState _:
                    HandleIdleState(actor);
                    break;
                case FleeingState _:
                    HandleFleeingState(actor);
                    break;
                case MeleeState _:
                    HandleMeleeState(actor);
                    break;
            }
        }

        private void HandleMeleeState(IActor actor)
        {
            if (actor.DetectionHandler.GetAnyTargetWithLoS() == null)
            {
                currentState = BehaviourStateProvider.Idle;
            }
            else if (actor.CurrentMeleeTarget == null)
            {
                currentState = BehaviourStateProvider.Fleeing;
            }
        }

        private void HandleFleeingState(IActor actor)
        {
            // TODO: Implement "Got away"
            if (false)
            {
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() == null)
            {
                currentState = BehaviourStateProvider.Idle;
            }
            else if (actor.CurrentMeleeTarget != null)
            {
                currentState = BehaviourStateProvider.Melee;
                actor.AttackTimer = actor.AttackCooldown;
            }
        }

        private void HandleIdleState(IActor actor)
        {
            if (actor.CurrentMeleeTarget != null)
            {
                currentState = BehaviourStateProvider.Melee;
                actor.AttackTimer = actor.AttackCooldown;
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() != null)
            {
                currentState = BehaviourStateProvider.Fleeing;
            }
        }
    }
}
