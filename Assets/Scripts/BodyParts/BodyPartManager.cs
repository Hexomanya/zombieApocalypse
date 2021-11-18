using System.Collections.Generic;
using UnityEngine;

public class BodyPartManager : MonoBehaviour
{
    public List<BodyPart> currentBodyParts = new List<BodyPart>();

    public void AttachBodyPart(BodyPart bodyPart)
    {
        currentBodyParts.Add(bodyPart);
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
