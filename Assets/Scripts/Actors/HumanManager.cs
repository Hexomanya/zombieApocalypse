using Assets.Scripts.Actors;
using UnityEngine;

public class HumanManager : ActorManagerBase
{
    public override void ActorDied(GameObject gameObject)
    {
        float dropRate = UnityEngine.Random.Range(0.25f, 0.5f);
        foreach (var item in Inventory.instance.bodyPartPrefabs)
        {
            float roll = UnityEngine.Random.Range(0f, 1f);
            if (roll <= dropRate)
            {
                Inventory.instance.AddBodyPart(item.New());
            }
        }

        DeleteActor(gameObject);   
    }
}
