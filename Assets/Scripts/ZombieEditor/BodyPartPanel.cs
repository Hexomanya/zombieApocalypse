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
        foreach (var slot in bodyPartSlots)
        {
            slot.InitializeUI(bodyParts);
        }
        ToggleBodyPartSlots(false);
    }

    public void UpdateUI(List<BodyPart> bodyParts)
    {
        foreach (var slot in bodyPartSlots)
        {
            slot.UpdateBodyPartCount(bodyParts);
        }
    }
}
