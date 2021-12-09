using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Visuals;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance;

    public static GameAssets Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            }

            return instance;
        }
    }

    [SerializeField] private List<ZombieSpriteHolder> zombieSprites = new List<ZombieSpriteHolder>();

    public Sprite GetZombieSprite(ZombieType zombieType, BodyPartType bodyPartType, SpriteOrientation spriteOrientation)
    {
        foreach (ZombieSpriteHolder item in zombieSprites)
        {
            if (item.ZombieType == zombieType && item.BodyPartType == bodyPartType && item.SpriteOrientation == spriteOrientation)
            {
                return item.ZombieSprite;
            }
        }

        return null;
    }
}
