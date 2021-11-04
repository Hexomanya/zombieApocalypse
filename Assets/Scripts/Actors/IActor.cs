using Assets.Scripts.Actors.ActorStates;
using Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public interface IActor
    {
        public DetectionHandler DetectionHandler { get; }

        public MeleeRangeHandler MeleeRangeHandler { get; }

        public float MeleeDamage { get; }

        public float AttackCooldown { get; }

        public float AttackTimer { get; set; }

        public float ConcentrationTime { get; }

        public float ConcentrationTimer { get; set; }

        public float PlayerCommandCooldown { get; }

        public AttackableObject CurrentMeleeTarget { get; set; }

        public IBehaviourState CurrentState { get; }

        public AIBase AIBase { get; }
    }
}
