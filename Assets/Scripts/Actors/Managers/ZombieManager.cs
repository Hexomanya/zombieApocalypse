using Assets.Scripts;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Interfaces;
using Pathfinding;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieManager : ActorManagerBase
{
    public GameObject ZombiePrefab;

    public override void Start()
    {
        if(Horde.instance == null) { return; }

        for (int i = 0; i < Horde.instance.zombies.Count; i++)
        {
            SpawnZombie(Horde.instance.zombies[i], i);
        }

        InitializeNodeBlocker();
    }

    public override void Update()
    {
        base.Update();
        if(blockerList.Count == 0)
        {
            endScreenPopup.GameOver();
        }
    }

    private void SpawnZombie(BodyPartManager bodyPartManager, int index)
    {
        GameObject gameObject = Instantiate(ZombiePrefab, transform);
        int numSpawnPos = SpawnPositions.Instance.Positions.Length;
        int posIndex;

        if(index < numSpawnPos){
            posIndex = index;
        } else {
            posIndex = index % numSpawnPos;
        }

        gameObject.transform.position = SpawnPositions.Instance.Positions[posIndex].position;

        ActorSpriteHandler actorSpriteHandler = gameObject.GetComponentInChildren<ActorSpriteHandler>();
        foreach (BodyPart bodypart in bodyPartManager.currentBodyParts)
        {
            foreach (SpriteOrientation orientation in Enum.GetValues(typeof(SpriteOrientation)))
            {
                actorSpriteHandler.SetSprite(GameAssets.Instance.GetZombieSprite(bodypart.zombieType, bodypart.type, orientation), orientation, bodypart.type);
            }

            actorSpriteHandler.EnableRenderBodyPart(bodypart.type);
        }

        IActor actor = gameObject.GetComponent<IActor>();
        actor.BodyPartManager = bodyPartManager;
        gameObject.GetComponent<IAstarAI>().maxSpeed = bodyPartManager.GetAllBodyPartStatModifiers().SpeedModifier;
        actor.MeleeDamage = bodyPartManager.GetAllBodyPartStatModifiers().MeleeDamageModifier;
        actor.ConcentrationTime = bodyPartManager.GetAllBodyPartStatModifiers().IntelligenceModifier;
        actor.MeleeAttackCooldown = bodyPartManager.GetAllBodyPartStatModifiers().MeleeCooldownTime;
        gameObject.GetComponentInChildren<DetectionHandler>().SetDetectionRange(bodyPartManager.GetAllBodyPartStatModifiers().DetectionRange);
        gameObject.GetComponent<AttackableObject>().MaxHealth = bodyPartManager.GetAllBodyPartStatModifiers().HealthModifier;

        blockerList.Add(gameObject.GetComponent<SingleNodeBlocker>());
    }

    public override void ActorDied(GameObject gameObject)
    {
        BodyPartManager bodyPartManager = gameObject.GetComponent<IActor>().BodyPartManager;
        foreach (var item in bodyPartManager.currentBodyParts)
        {
            if (item.type != BodyPartType.Torso)
            {
                float roll = Random.Range(0f, 1f);
                if (roll <= GameManager.Instance.BodyPartDropChance)
                {
                    Inventory.instance.AddNewBodyPart(item);
                }
            }
        }

        Horde.instance.RemoveZombie(bodyPartManager);
        DeleteActor(gameObject);
    }
}
