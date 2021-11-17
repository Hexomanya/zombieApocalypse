using UnityEngine;

public class BodyPartManager : MonoBehaviour
{
    // This represents the attached BodyParts to a Zombie
    // [0] for example is the head of the Zombie, if the does not have any it is null
    // Create the BodyPartsArray with Length 6 (Head, LeftArm, Torso, RightArm, LeftFoot, RightFoot)
    public BodyPart[] currentBodyParts = new BodyPart[System.Enum.GetNames(typeof(BodyPartType)).Length];


    public void AttachBodyPart(BodyPart bodyPart)
    {
        // Attach BodyPart to the corresponding slot
        currentBodyParts[(int) bodyPart.Type] = bodyPart; 
    }

    public BodyPartStatModifier GetAllBodyPartStatModifiers()
    {
        var result = new BodyPartStatModifier();

        for (int i = 0; i < currentBodyParts.Length; i++)
        {
            if( currentBodyParts[i] != null)
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
