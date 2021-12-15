using Assets.Scripts.Actors.ActorTypes;
using Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Actors.Interfaces
{
    public interface IActor
    {
        public ActorType Typ { get; }
        public DetectionHandler DetectionHandler { get; }

        public MeleeRangeHandler MeleeRangeHandler { get; }

        public RangeAttackHandler RangeAttackHandler { get; }

        public float MeleeDamage { get; set; }

        public float MeleeAttackCooldown { get; set; }

        public float MeleeAttackTimer { get; set; }

        public float ConcentrationTime { get; set; }

        public float ConcentrationTimer { get; set; }

        public float PlayerCommandCooldown { get; }

        public AttackableObject CurrentMeleeTarget { get; set; }

        public IBehaviourState CurrentState { get; }

        public IAstarAI AstarAI { get; }

        public Transform LastKnownTargetPosition { get; set; }

        public Vector3 SpawnPos { get; }

        public PatrollRoute PatrollRoute { get; }

        public int WaypointIndex { get; set; }

        public SingleNodeBlocker NodeBlocker {get; set;}

        public BlockManager BlockManager { get; }

        public ActorManagerBase ActorManager { get; }

        public BodyPartManager BodyPartManager { get; set; }

        public Animator Animator { get; }

        public AudioSource AudioSource { get; set; }

        public bool DeativatePathBlocking { get; set; }
    }
}
