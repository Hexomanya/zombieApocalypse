using Assets.Scripts;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Interfaces;
using Pathfinding;
using UnityEngine;

public class ZombieManager : ActorManagerBase
{
    public GameObject ZombiePrefab;

    void Start()
    {
        for (int i = 0; i < Horde.instance.zombies.Count; i++)
        {
            SpawnZombie(Horde.instance.zombies[i], i);
        }

        InitializeNodeBlocker();
    }

    void Update()
    {
    }

    private void SpawnZombie(BodyPartManager bodyPartManager, int index)
    {
        GameObject gameObject = Instantiate<GameObject>(ZombiePrefab, transform);
        gameObject.GetComponent<BodyPartManager>().currentBodyParts = bodyPartManager.currentBodyParts;
        gameObject.transform.position = SpawnPositions.Instance.Positions[index].position;
        IActor actor = gameObject.GetComponent<IActor>();
        gameObject.GetComponent<IAstarAI>().maxSpeed = bodyPartManager.GetAllBodyPartStatModifiers().SpeedModifier;
        actor.MeleeDamage = bodyPartManager.GetAllBodyPartStatModifiers().DamageModifier;
        actor.ConcentrationTime = bodyPartManager.GetAllBodyPartStatModifiers().IntelligenceModifier;
        gameObject.GetComponent<AttackableObject>().MaxHealth = bodyPartManager.GetAllBodyPartStatModifiers().HealthModifier;

        blockerList.Add(gameObject.GetComponent<SingleNodeBlocker>());
    }
}
