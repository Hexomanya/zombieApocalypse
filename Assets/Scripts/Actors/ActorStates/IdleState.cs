using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Actors.ActorStates
{
    public class IdleState : IBehaviourState
    {
        public string StateName => "Idle";

        public void EnterState(GameObject gameObject, IActor actor, IActorType actorType)
        {
            actor.AstarAI.SetPath(null);
            actor.AstarAI.canMove = false;

            if (actor.ConcentrationTime > 0)
            {
                SoundEffectManager.Instance.PlaySound(SoundEffectManager.SoundEffect.ZombieConfused, actor.AudioSource);
            }
        }

        public void ExitState(GameObject gameObject, IActor actor)
        {
            // do nothing
        }

        public void Update(GameObject gameObject, IActor actor, IActorType actorType)
        {
            //TODO Get Zombie type
            if (actor.ConcentrationTime > 0)
            {
                SoundEffectManager.Instance.PlayZombieGrowl(actor.AudioSource);
            }
        }
    }
}
