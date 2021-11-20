using Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Actors.Interfaces
{
    public interface IActorType
    {
        public IBehaviourState CurrentState { get; }

        public ABPath Path { get; }

        public float PlayerCommandCooldownTimer { get; set; }

        public void DecideOnNextState(GameObject gameObject, IActor actor);

        public void UpdatePath(Vector3 currentPos, Vector3 destination, IActor actor, bool forceCall = false, bool ignorePathBlocking = false);
    }
}
