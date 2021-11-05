namespace Assets.Scripts.Actors.ActorStates
{
    public static class BehaviourStateProvider
    {
        private static readonly IBehaviourState fleeing = new FleeingState();
        private static readonly IBehaviourState idle = new IdleState();
        private static readonly IBehaviourState melee = new MeleeState();
        private static readonly IBehaviourState engaging = new EngageState();
        private static readonly IBehaviourState searching = new SearchState();
        private static readonly IBehaviourState playerMoveCommandState = new PlayerMoveCommandState();
        private static readonly IBehaviourState returningState = new ReturningState();
        private static readonly IBehaviourState patrollingState = new PatrollingState();

        public static IBehaviourState Idle => idle;
        public static IBehaviourState Fleeing => fleeing;
        public static IBehaviourState Melee => melee;
        public static IBehaviourState Engaging => engaging;
        public static IBehaviourState Searching => searching;
        public static IBehaviourState PlayerMoveCommandState => playerMoveCommandState;
        public static IBehaviourState Returning => returningState;
        public static IBehaviourState Patrolling => patrollingState;
    }
}
