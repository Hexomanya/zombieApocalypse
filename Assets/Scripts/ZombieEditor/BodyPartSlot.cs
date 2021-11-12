using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyPartSlot : MonoBehaviour
{
    public Text uiText;

    public GameObject bodyPartPrefab;

    public BodyPartType bodyPartType;


    public void InitializeUI(List<BodyPart> bodyParts)
    {
        UpdateBodyPartCount(bodyParts);
        foreach (var bodyPart in bodyParts)
        {
            if (bodyPart.Type == bodyPartType)
            {
                Instantiate(bodyPartPrefab, transform);
            }
        }
    }

    public void UpdateBodyPartCount(List<BodyPart> bodyParts)
    {
        int count = 0;
        foreach (var bodyPart in bodyParts)
        {
            if (bodyPart.Type == bodyPartType)
                count++;
        }

        uiText.text = count.ToString();
    }
}
