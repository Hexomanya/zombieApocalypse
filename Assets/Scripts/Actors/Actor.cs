using Assets.Scripts.Actors.ActorStates;
using Assets.Scripts.Actors.ActorTypes;
using Pathfinding;
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
        public float AttackCooldown { get; private set; } = 2f;

        [field: SerializeField]
        public float ConcentrationTime { get; private set; } = 5f;

        [field: SerializeField]
        public float PlayerCommandCooldown { get; private set; } = 2f;

        public AttackableObject CurrentMeleeTarget { get; set; }

        public IBehaviourState CurrentState => myActorType.CurrentState;

        public float AttackTimer { get; set; } = 0f;

        public float ConcentrationTimer { get; set; } = 0f;

        public DetectionHandler DetectionHandler { get; private set; }

        public MeleeRangeHandler MeleeRangeHandler { get; private set; }

        public AIBase AIBase { get; private set; }

        void Awake()
        {
            DetectionHandler = GetComponentInChildren<DetectionHandler>();
            MeleeRangeHandler = GetComponentInChildren<MeleeRangeHandler>();
            AttackTimer = AttackCooldown;
            myActorType = ActorTypeProvider.GetActorType(Typ);
            AIBase = GetComponent<AIBase>();
        }

        void Update()
        {
            CurrentState.Update(gameObject, this);
            myActorType.DecideOnNextState(gameObject, this);
        }
    }
}
