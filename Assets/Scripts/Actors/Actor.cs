using Assets.Scripts.Actors.ActorTypes;
using Assets.Scripts.Actors.Interfaces;
using Pathfinding;
using System;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class Actor : MonoBehaviour, IActor
    {
        private IActorType myActorType;

        [field: SerializeField]
        private ActorType Typ { get; set; } = ActorType.Zombie;

        [field: SerializeField]
        public float MeleeDamage { get; private set; } = 5f;

        [field: SerializeField]
        public float MeleeAttackCooldown { get; private set; } = 2f;

        [field: SerializeField]
        public float ConcentrationTime { get; private set; } = 5f;

        [field: SerializeField]
        public float PlayerCommandCooldown { get; private set; } = 2f;

        public AttackableObject CurrentMeleeTarget { get; set; }

        public IBehaviourState CurrentState => myActorType.CurrentState;

        public float MeleeAttackTimer { get; set; } = 0f;

        public float ConcentrationTimer { get; set; } = 0f;

        public DetectionHandler DetectionHandler { get; private set; }

        public MeleeRangeHandler MeleeRangeHandler { get; private set; }

        public RangeAttackHandler RangeAttackHandler { get; private set; }

        public IAstarAI AstarAI { get; private set; }
        public Transform LastKnownTargetPosition { get; set; }

        public Vector3 SpawnPos { get; private set; }

        [field: SerializeField]
        public PatrollRoute PatrollRoute { get; private set; }

        public int WaypointIndex { get; set; } = 0;

        public SingleNodeBlocker NodeBlocker { get; set; }

        public BlockManager BlockManager { get; private set; }

        public ActorManager ActorManager { get; private set; }

        void Awake()
        {
            DetectionHandler = GetComponentInChildren<DetectionHandler>();
            MeleeRangeHandler = GetComponentInChildren<MeleeRangeHandler>();
            RangeAttackHandler = GetComponent<RangeAttackHandler>();
            NodeBlocker = GetComponent<SingleNodeBlocker>();
            BlockManager = FindObjectOfType<BlockManager>();
            
            if (transform.parent.GetComponent<ActorManager>() == null)
            {
                throw new ArgumentException($"{gameObject.name} is not folded under a ActorManager Script!");
            }

            ActorManager = transform.parent.GetComponent<ActorManager>();
            MeleeAttackTimer = MeleeAttackCooldown;
            myActorType = ActorTypeProvider.GetActorType(Typ);
            AstarAI = GetComponent<IAstarAI>();
            SpawnPos = transform.position;
        }

        void Update()
        {
            NodeBlocker?.Unblock();
            NodeBlocker?.BlockAtCurrentPosition();
            CurrentState.Update(gameObject, this, myActorType);
            myActorType.DecideOnNextState(gameObject, this);
        }
    }
}
