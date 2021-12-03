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

        for (int i = 0; i < currentBodyParts.Count; i++)
        {
            if(currentBodyParts[i] != null)
            {
                result.DamageModifier += currentBodyParts[i].damageModifier;
                result.HealthModifier += currentBodyParts[i].healthModifier;
                result.SpeedModifier += currentBodyParts[i].speedModifier;
                result.IntelligenceModifier += currentBodyParts[i].intelligenceModifier;
            }
        }
        return result;
    }

}
