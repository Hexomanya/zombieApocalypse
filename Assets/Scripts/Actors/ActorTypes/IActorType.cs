using Assets.Scripts.Actors.ActorStates;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorTypes
{
    public interface IActorType
    {
        public IBehaviourState CurrentState { get; }

        public float PlayerCommandCooldownTimer { get; set; }

        public void DecideOnNextState(GameObject gameObject, IActor actor);
    }
}
