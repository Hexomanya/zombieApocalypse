using Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Actors.Interfaces
{
    public interface IActor
    {
        public DetectionHandler DetectionHandler { get; }

        public MeleeRangeHandler MeleeRangeHandler { get; }

        public RangeAttackHandler RangeAttackHandler { get; }

        public float MeleeDamage { get; }

        public float MeleeAttackCooldown { get; }

        public float MeleeAttackTimer { get; set; }

        public float ConcentrationTime { get; }

        public float ConcentrationTimer { get; set; }

        public float PlayerCommandCooldown { get; }

        public AttackableObject CurrentMeleeTarget { get; set; }

        public IBehaviourState CurrentState { get; }

        public IAstarAI AstarAI { get; }

        public Transform LastKnownTargetPosition { get; set; }

        public Vector3 SpawnPos { get; }

        public PatrollRoute PatrollRoute { get; }

        public int WaypointIndex { get; set; }
    }
}
