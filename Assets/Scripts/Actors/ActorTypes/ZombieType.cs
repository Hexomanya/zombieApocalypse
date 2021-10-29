using Assets.Scripts.Actors.ActorStates;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorTypes
{
    public class ZombieType : IActorType
    {
        private IBehaviourState currentState = BehaviourStateProvider.Idle;

        public IBehaviourState CurrentState => currentState;

        private float PlayerCommandCooldownTimer { get; set; } = 0f;

        public void DecideOnNextState(GameObject gameObject, IActor actor)
        {
            actor.CurrentMeleeTarget = actor.MeleeRange.GetPossibleTarget();
            // prevent underflow
            if (PlayerCommandCooldownTimer > 0f)
            {
                PlayerCommandCooldownTimer -= Time.deltaTime;
            }

            switch (actor.CurrenState)
            {
                case IdleState _:
                    HandleIdleState(actor);
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
                case PlayerMoveCommandState _:
                    HandlePlayerMoveCommandState(gameObject, actor);
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
            actor.CurrentMoveTarget = actor.DetectionHandler.GetAnyTargetWithLoS() != null
                ? actor.DetectionHandler.GetClosestTargetWithLoS().transform.position
                : gameObject.transform.position;

            if (Input.GetMouseButtonDown(0) && PlayerCommandCooldownTimer <= 0f)
            {
                SwitchToPlayerMoveCommandState(actor);
            }
            else if (actor.CurrentMoveTarget != gameObject.transform.position)
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
            else if (Input.GetMouseButtonDown(0) && PlayerCommandCooldownTimer <= 0f)
            {
                SwitchToPlayerMoveCommandState(actor);
            }
            else if (actor.DetectionHandler.GetAnyTargetWithLoS() == null)
            {
                currentState = BehaviourStateProvider.Idle;
            }
        }

        private void HandleIdleState(IActor actor)
        {
            if (Input.GetMouseButtonDown(0) && PlayerCommandCooldownTimer <= 0f)
            {
                SwitchToPlayerMoveCommandState(actor);
            }
            else if (actor.DetectionHandler.IsAnyTargetInRange())
            {
                currentState = BehaviourStateProvider.Searching;
            }
        }

        private void HandlePlayerMoveCommandState(GameObject gameObject, IActor actor)
        {
            if (Input.GetMouseButtonDown(0) && PlayerCommandCooldownTimer <= 0f)
            {
                SwitchToPlayerMoveCommandState(actor);
            }
            else if (actor.CurrentMeleeTarget != null)
            {
                currentState = BehaviourStateProvider.Melee;
            }
            else if (actor.ConcentrationTimer <= 0f || Utility.RemoveNumberFractions(actor.CurrentMoveTarget - gameObject.transform.position, true) == Vector3.zero)
            {
                currentState = BehaviourStateProvider.Searching;
            }

            // prevent underflow
            if (actor.ConcentrationTimer > 0f)
            {
                actor.ConcentrationTimer -= Time.deltaTime;
            }
        }

        private void SwitchToPlayerMoveCommandState(IActor actor)
        {
            actor.CurrentMoveTarget = Utility.RemoveZAxis(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            currentState = BehaviourStateProvider.PlayerMoveCommandState;
            actor.ConcentrationTimer = actor.ConcentrationTime;
            PlayerCommandCooldownTimer = actor.PlayerCommandCooldown;
        }
    }
}
