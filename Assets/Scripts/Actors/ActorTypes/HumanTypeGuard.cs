using Assets.Scripts.Actors.ActorStates;
using System;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorTypes
{
    public class HumanTypeGuard : IActorType
    {
        private IBehaviourState currentState = BehaviourStateProvider.Idle;

        public IBehaviourState CurrentState => currentState;

        public void DecideOnNextState(GameObject gameObject, IActor actor)
        {
            actor.CurrentMoveTarget = actor.DetectionHandler.GetAnyTargetWithLoS() != null
                ? actor.DetectionHandler.GetClosestTargetWithLoS().transform.position
                : gameObject.transform.position;
            actor.CurrentMeleeTarget = actor.MeleeRange.GetPossibleTarget();

            switch (actor.CurrenState)
            {
                case IdleState _:
                    HandleIdleState(gameObject, actor);
                    break;
                case EngageState _:
                    HandleEngagingState(actor);
                    break;
                case MeleeState _:
                    HandleMeleeState(actor);
                    break;
                case SearchState _:
                    HandleSearchingState(gameObject, actor);
                    break;
            }
        }

        private void HandleMeleeState(IActor actor)
        {
            if (actor.CurrentMeleeTarget == null)
            {
                currentState = BehaviourStateProvider.Searching;
            }
        }

        private void HandleSearchingState(GameObject gameObject, IActor actor)
        {
            if(actor.CurrentMoveTarget != gameObject.transform.position)
            {
                currentState = BehaviourStateProvider.Engaging;
            }
            else if (!actor.DetectionHandler.IsAnyTargetInRange())
            {
                currentState = BehaviourStateProvider.Idle;
            }
        }

        private void HandleEngagingState(IActor actor)
        {
            if (actor.CurrentMeleeTarget != null)
            {
                currentState = BehaviourStateProvider.Melee;
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() == null)
            {
                currentState = BehaviourStateProvider.Idle;
            }
        }

        private void HandleIdleState(GameObject gameObject, IActor actor)
        {
            if (actor.DetectionHandler.IsAnyTargetInRange())
            {
                currentState = BehaviourStateProvider.Searching;
            }
            else if (actor.CurrentMoveTarget != gameObject.transform.position)
            {
                currentState = BehaviourStateProvider.Engaging;
            }
        }
    }
}
