using Assets.Scripts.Actors.ActorStates;
using Assets.Scripts.Actors.ActorTypes;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class Zombie : MonoBehaviour, IActor
    {
        private IActorType myActorType;

        [field: SerializeField]
        private ActorType Typ { get; set; } = ActorType.Zombie;

        [field: SerializeField]
        public float MoveSpeed { get; private set; } = 3f;

        [field: SerializeField]
        public float MeleeDamage { get; private set; } = 5f;

        [field: SerializeField]
        public float AttackCooldown { get; private set; } = 2f;

        [field: SerializeField]
        public float ConcentrationTime { get; private set; } = 5f;

        [field: SerializeField]
        public float PlayerCommandCooldown { get; private set; } = 2f;

        public AttackableObject CurrentMeleeTarget { get; set; }

        public IBehaviourState CurrenState => myActorType.CurrentState;

        public float AttackTimer { get; set; } = 0f;

        public float ConcentrationTimer { get; set; } = 0f;

        public DetectionHandler DetectionHandler { get; private set; }

        public MeleeRangeHandler MeleeRange { get; private set; }

        public Vector3 CurrentMoveTarget { get; set; }

        void Awake()
        {
            DetectionHandler = GetComponentInChildren<DetectionHandler>();
            MeleeRange = GetComponentInChildren<MeleeRangeHandler>();
            AttackTimer = AttackCooldown;
            myActorType = ActorTypeProvider.GetActorType(Typ);
        }

        void Update()
        {
            CurrenState.Update(gameObject, this);
            myActorType.DecideOnNextState(gameObject, this);
        }
    }
}
