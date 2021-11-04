using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartContentManager : MonoBehaviour
{
    [field: SerializeField]
    private BodyPartType bodyPartType { get; } = BodyPartType.Head;

    [field: SerializeField]
    private HordeManager horde { get; }

    void Start()
    {
        if(horde != null)
        {
            var bodyPartList = horde.GetComponentsInChildren<BodyPartType>();
            foreach (var bodyPart in bodyPartList)
            {
                //gameObject.transform.SetAsLastSibling(bodyPart.gameObject);
            }
        }
    }

}
