using Assets.Scripts;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Interfaces;
using Pathfinding;
using UnityEngine;

public class ZombieManager : ActorManagerBase
{
    public GameObject ZombiePrefab;

    public override void Start()
    {
        for (int i = 0; i < Horde.instance.zombies.Count; i++)
        {
            SpawnZombie(Horde.instance.zombies[i], i);
        }

        InitializeNodeBlocker();
    }

    private void SpawnZombie(BodyPartManager bodyPartManager, int index)
    {
        GameObject gameObject = Instantiate(ZombiePrefab, transform);
        gameObject.GetComponent<BodyPartManager>().currentBodyParts = bodyPartManager.currentBodyParts;
        gameObject.transform.position = SpawnPositions.Instance.Positions[index].position;
        IActor actor = gameObject.GetComponent<IActor>();
        gameObject.GetComponent<IAstarAI>().maxSpeed = bodyPartManager.GetAllBodyPartStatModifiers().SpeedModifier;
        actor.MeleeDamage = bodyPartManager.GetAllBodyPartStatModifiers().DamageModifier;
        actor.ConcentrationTime = bodyPartManager.GetAllBodyPartStatModifiers().IntelligenceModifier;
        gameObject.GetComponent<AttackableObject>().MaxHealth = bodyPartManager.GetAllBodyPartStatModifiers().HealthModifier;

        blockerList.Add(gameObject.GetComponent<SingleNodeBlocker>());
    }

    public override void ActorDied(GameObject gameObject)
    {
        BodyPartManager bodyPartManager = gameObject.GetComponent<BodyPartManager>();
        float dropRate = Random.Range(0.25f, 0.5f);
        foreach (var item in bodyPartManager.currentBodyParts)
        {
            if (item.Type != BodyPartType.Torso)
            {
                float roll = Random.Range(0f, 1f);
                if (roll <= dropRate)
                {
                    Inventory.instance.AddNewBodyPart(item);
                }
            }
        }

        DeleteActor(gameObject);
    }
}
