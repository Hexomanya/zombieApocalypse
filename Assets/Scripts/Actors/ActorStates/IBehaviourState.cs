using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public interface IBehaviourState
    {
        public string StateName { get; }

        public void Update(GameObject gameObject, IActor actor);
    }
}
