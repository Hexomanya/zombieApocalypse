using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyPartPanel : MonoBehaviour
{
    private BodyPartSlot[] bodyPartSlots;

    private bool isExpanded = true;

    private void Awake()
    {
        bodyPartSlots = GetComponentsInChildren<BodyPartSlot>();
    }

    public void ToggleBodyPartSlots(bool expand)
    {
        isExpanded = expand;
        foreach (var slot in bodyPartSlots)
        {
            slot.gameObject.SetActive(isExpanded);
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
