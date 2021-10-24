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

        public static IBehaviourState Idle => idle;
        public static IBehaviourState Fleeing => fleeing;
        public static IBehaviourState Melee => melee;
        public static IBehaviourState Engaging => engaging;
        public static IBehaviourState Searching => searching;
        public static IBehaviourState PlayerMoveCommandState => playerMoveCommandState;
    }
}
