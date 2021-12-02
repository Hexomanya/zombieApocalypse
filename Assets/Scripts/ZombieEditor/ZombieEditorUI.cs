using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieEditorUI : MonoBehaviour
{
    private Inventory _inventory;

    private Horde _horde;

    private TemplatePanel[] _templatePanels;

    private BodyPartPanel[] _bodyPartPanels;

    private HordePanel _hordePanel;

    void Awake()
    {
        _templatePanels = GetComponentsInChildren<TemplatePanel>();
        _bodyPartPanels = GetComponentsInChildren<BodyPartPanel>();
        _hordePanel = GetComponentInChildren<HordePanel>();
    }


    void Start()
    {
        _inventory = Inventory.instance;
        //Subscribing to Inventory Event
        _inventory.onBodyPartsChangedCallback += UpdateUI;

        _horde = Horde.instance;
        _horde.onHordeChangedCallback += UpdateUI;

        if(_horde.zombies.Count == 0)
        {
            _horde.AddEmptyZombie();
        }

        InitializeUI();
    }

    void InitializeUI()
    {
        _hordePanel.InitializeUI(_horde.zombies);
        foreach (var panel in _templatePanels)
        {
            panel.InitializeUI(_horde.GetSelectedZombie());
        }
        foreach (var panel in _bodyPartPanels)
        {
            panel.InitializeUI(_inventory.bodyParts);
        }
    }

    void UpdateUI()
    {
        _hordePanel.UpdateUI(_horde.zombies);
        foreach (var panel in _templatePanels)
        {
            panel.InitializeUI(_horde.GetSelectedZombie());
        }
        foreach (var panel in _bodyPartPanels)
        {
            panel.UpdateUI(_inventory.bodyParts);
        }
    }

    public void OnZombieAddButtonClicked()
    {
        _horde.AddEmptyZombie();
    }

    public void OnStartGameButtonClicked()
    {
        //Do animations here
        GameManager.Instance.LoadNextLevel();
    }
}
