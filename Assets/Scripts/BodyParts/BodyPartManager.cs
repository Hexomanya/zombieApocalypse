using System.Collections.Generic;
using UnityEngine;

public class BodyPartManager : MonoBehaviour
{
    public List<BodyPart> currentBodyParts = new List<BodyPart>();

    public bool AttachBodyPart(BodyPart bodyPart)
    {
        if (!HasBodyPartOfType(bodyPart.type))
        {
            currentBodyParts.Add(bodyPart);
            return true;
        }
        return false;
    }

    public bool HasBodyPartOfType(BodyPartType bodyPartType)
    {
        foreach(var bodyPart in currentBodyParts)
        {
            if (bodyPart.type == bodyPartType)
                return true;
        }
        return false;
    }

    public BodyPartStatModifier GetAllBodyPartStatModifiers()
    {
        var result = new BodyPartStatModifier();

        foreach (var item in currentBodyParts)
        {
            result.MeleeDamageModifier += item.meleeDamageModifier;
            result.MeleeCooldownTime += item.meleeCooldownTime;
            result.HealthModifier += item.healthModifier;
            result.SpeedModifier += item.speedModifier;
            result.IntelligenceModifier += item.intelligenceModifier;
            result.DetectionRange += item.detectionRange;
        }

        return result;
    }

}
