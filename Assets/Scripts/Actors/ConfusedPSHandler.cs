using Assets.Scripts.Actors.ActorStates;
using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

public class ConfusedPSHandler : MonoBehaviour
{
    private ParticleSystem particle;
    private IActor actor;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        actor = GetComponentInParent<IActor>();
    }

    void Update()
    {
        if (actor.CurrentState is IdleState && actor.ConcentrationTimer <= 0f && !particle.isPlaying)
        {
            particle.Play();
        }
    }
}
