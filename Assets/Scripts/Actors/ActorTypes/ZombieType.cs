using Assets.Scripts.Actors.ActorStates;
using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorTypes
{
    public class ZombieType : IActorType
    {
        private IBehaviourState currentState = BehaviourStateProvider.Idle;

        public IBehaviourState CurrentState => currentState;

        public float PlayerCommandCooldownTimer { get; set; } = 0f;

        public void DecideOnNextState(GameObject gameObject, IActor actor)
        {
            // prevent underflow
            if (PlayerCommandCooldownTimer > 0f)
            {
                PlayerCommandCooldownTimer -= Time.deltaTime;
            }

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
                case PlayerMoveCommandState _:
                    HandlePlayerMoveCommandState(gameObject, actor);
                    break;
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
            if (Input.GetMouseButtonDown(0) && PlayerCommandCooldownTimer <= 0f)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.PlayerMoveCommandState);
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() != null)
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
            else if (Input.GetMouseButtonDown(0) && PlayerCommandCooldownTimer <= 0f)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.PlayerMoveCommandState);
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() == null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Idle);
            }
        }

        private void HandleIdleState(GameObject gameObject, IActor actor)
        {
            if (Input.GetMouseButtonDown(0) && PlayerCommandCooldownTimer <= 0f)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.PlayerMoveCommandState);
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Engaging);
            }
            else if (actor.LastKnownTargetPosition != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Searching);
            }
        }

        private void HandlePlayerMoveCommandState(GameObject gameObject, IActor actor)
        {
            if (Input.GetMouseButtonDown(0) && PlayerCommandCooldownTimer <= 0f)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.PlayerMoveCommandState);
            }
            else if (actor.MeleeRangeHandler.GetPossibleTarget() != null)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Melee);
            }
            else if (actor.ConcentrationTimer <= 0f || actor.AstarAI.reachedDestination)
            {
                SwitchState(gameObject, actor, BehaviourStateProvider.Searching);
            }

            // prevent underflow
            if (actor.ConcentrationTimer > 0f)
            {
                actor.ConcentrationTimer -= Time.deltaTime;
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
