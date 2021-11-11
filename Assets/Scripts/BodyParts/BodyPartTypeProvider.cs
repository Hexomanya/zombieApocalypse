using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BodyPartTypeProvider 
{
    public static IBodyPartType GetActorType(BodyPartType type)
    {
        return type switch
        {
            BodyPartType.Head => new Head(),
            BodyPartType.LeftArm => new LeftArm(),
            BodyPartType.RightArm => new RightArm(),
            BodyPartType.LeftFoot => new LeftFoot(),
            BodyPartType.RightFoot => new RightFoot(),
            _ => throw new System.ArgumentException($"No BodyPart of type {type} available."),
        };
    }
}
