using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyPartSlot : MonoBehaviour
{
    public Text uiText;

    public GameObject bodyPartPrefab;

    public BodyPartType bodyPartType;

    public ZombieType zombieType;


    public void InitializeUI(List<BodyPart> bodyParts)
    {
        UpdateBodyPartCount(bodyParts);
        foreach (var bodyPart in bodyParts)
        {
            if (bodyPart.type == bodyPartType && bodyPart.zombieType == zombieType)
            {
                var dragHandler = Instantiate(bodyPartPrefab, transform).GetComponent<DragHandler>();
                dragHandler.bodyPart = bodyPart;
            }
        }
    }

    public void UpdateBodyPartCount(List<BodyPart> bodyParts)
    {
        int count = 0;
        foreach (var bodyPart in bodyParts)
        {
            if (bodyPart.type == bodyPartType && bodyPart.zombieType == zombieType)
                count++;
        }

        uiText.text = count.ToString();
    }
}
