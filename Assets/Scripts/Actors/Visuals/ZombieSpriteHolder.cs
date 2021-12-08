using System;
using UnityEngine;

namespace Assets.Scripts.Actors.Visuals
{
    [Serializable]
    public class ZombieSpriteHolder
    {
        [field: SerializeField] public ZombieType ZombieType { get; private set; }
        [field: SerializeField] public BodyPartType BodyPartType { get; private set; }
        [field: SerializeField] public SpriteOrientation SpriteOrientation { get; private set; }

        [field: SerializeField] public Sprite ZombieSprite { get; private set; }
    }
}
