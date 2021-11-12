using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartManager : MonoBehaviour
{
    BodyPart[] attachedBodyParts;

    private void Start()
    {
        // Create the BodyPartsArray with Length 5 (Head, LeftArm, RightArm, LeftFoot, RightFoot)
        attachedBodyParts = new BodyPart[System.Enum.GetNames(typeof(BodyPartType)).Length];
    }

    public void AttachBodyPart(BodyPart bodyPart)
    {
        // Attach BodyPart to the corresponding slot
        attachedBodyParts[(int) bodyPart.Type] = bodyPart; 
    }

}
