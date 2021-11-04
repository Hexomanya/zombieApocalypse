using Assets.Scripts.Actors.ActorTypes;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public interface IBehaviourState
    {
        public string StateName { get; }

        public void Update(GameObject gameObject, IActor actor);

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType);

        public void ExitState(GameObject gameObject, IActor actor);
    }
}
