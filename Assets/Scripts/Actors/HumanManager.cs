using Assets.Scripts.Actors;
using UnityEngine;

public class HumanManager : ActorManagerBase
{
    public override void ActorDied(GameObject gameObject)
    {
        float dropRate = Random.Range(0.25f, 0.5f);
        foreach (var item in Horde.instance.availableBodyParts)
        {
            if (item.Type == BodyPartType.Torso)
            {
                continue;
            }

            float roll = Random.Range(0f, 1f);
            if (roll <= dropRate)
            {
                BodyPart bodyPart = item.New();
                Inventory.instance.AddNewBodyPart(bodyPart);
                PickUpMessageHandler.Instance.AddNewMessage(bodyPart.name);
            }
        }

        DeleteActor(gameObject);   
    }
}
