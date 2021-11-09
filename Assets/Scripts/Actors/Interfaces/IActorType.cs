using Assets.Scripts.Actors.ActorStates;
using UnityEngine;

namespace Assets.Scripts.Actors.Interfaces
{
    public interface IActorType
    {
        public IBehaviourState CurrentState { get; }

        public float PlayerCommandCooldownTimer { get; set; }

        public void DecideOnNextState(GameObject gameObject, IActor actor);
    }
}
