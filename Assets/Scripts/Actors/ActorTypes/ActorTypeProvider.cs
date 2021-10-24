namespace Assets.Scripts.Actors.ActorTypes
{
    public static class ActorTypeProvider
    {
        public static IActorType GetActorType(ActorType type)
        {
            return type switch
            {
                ActorType.HumanFleeing => new HumanTypeFleeing(),
                ActorType.HumanGuard => new HumanTypeGuard(),
                ActorType.Zombie => new ZombieType(),
                _ => throw new System.ArgumentException($"No Actor of type {type} available."),
            };
        }
    }
}
