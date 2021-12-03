using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUi : MonoBehaviour
{

    public static InGameUi instance;

    private BodyPartInventorySlot[] _inventorySlots;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More then one InGameUi instance has been found!");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        _inventorySlots = GetComponentsInChildren<BodyPartInventorySlot>();
    }
    
    
    public void ShowBodyPartCollectedPopUp(BodyPart bodyPart)
    {
        foreach (var slot in _inventorySlots)
        {
            if (bodyPart.type == slot.bodyPartType && bodyPart.zombieType == slot.zombieType)
                slot.UpdateUI();
        }
    }


}
