using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyPartPanel : MonoBehaviour
{
    private BodyPartSlot[] bodyPartSlots;

    private void Awake()
    {
        bodyPartSlots = GetComponentsInChildren<BodyPartSlot>();
    }

    public void ToggleBodyPartSlots(bool expand)
    {
        var imageComponent = GetComponent<Image>();
        if (expand)
            imageComponent.color = Color.white;
        else
            imageComponent.color = Color.grey;

        foreach (var slot in bodyPartSlots)
        {
            slot.gameObject.SetActive(expand);
        }
    }


    public void InitializeUI(List<BodyPart> bodyParts)
    {
        if(bodyParts != null && bodyParts.Count > 0) 
        {
            foreach (var slot in bodyPartSlots)
            {
                slot.InitializeUI(bodyParts);
            }
            ToggleBodyPartSlots(false);
        }
        else
        {
            Debug.LogError("Bodypart null");
        }
    }

    public void UpdateUI(List<BodyPart> bodyParts)
    {
        if(bodyPartSlots != null && bodyPartSlots.Length > 0)
        {
            foreach (var slot in bodyPartSlots)
            {
                slot.UpdateBodyPartCount(bodyParts);
            }
        }
        else
        {
            Debug.LogError("Bodypartslots null");
        }
        
    }
}
