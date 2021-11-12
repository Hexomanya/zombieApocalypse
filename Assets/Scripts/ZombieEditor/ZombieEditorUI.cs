using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieEditorUI : MonoBehaviour
{
    private Inventory inventory;

    private Horde horde;
    
    private BodyPartPanel[] bodyPartPanels;

    private HordePanel hordePanel;

    void Awake()
    {
        bodyPartPanels = GetComponentsInChildren<BodyPartPanel>();
        hordePanel = GetComponentInChildren<HordePanel>();
    }


    void Start()
    {
        inventory = Inventory.instance;
        //Subscribing to Inventory Event
        inventory.onBodyPartsChangedCallback += UpdateUI;

        horde = Horde.instance;
        horde.onHordeChangedCallback += UpdateUI;

        InitializeUI();
    }

    void InitializeUI()
    {
        foreach (var panel in bodyPartPanels)
        {
            panel.InitializeUI(inventory.bodyParts);
        }
        hordePanel.InitializeUI(horde.zombies);
    }

    void UpdateUI()
    {
        foreach (var panel in bodyPartPanels)
        {
            panel.UpdateUI(inventory.bodyParts);
        }

        hordePanel.UpdateUI(horde.zombies);
    }

}
