using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieEditorUI : MonoBehaviour
{
    private Inventory _inventory;

    private Horde _horde;

    private TemplatePanel[] _templatePanels;

    private BodyPartPanel[] _bodyPartPanels;

    private HordePanel _hordePanel;

    private TorsoTemplate _torsoTemplate;

    void Awake()
    {
        _templatePanels = GetComponentsInChildren<TemplatePanel>();
        _bodyPartPanels = GetComponentsInChildren<BodyPartPanel>();
        _hordePanel = GetComponentInChildren<HordePanel>();
        _torsoTemplate = GetComponentInChildren<TorsoTemplate>();
    }


    void Start()
    {
        _inventory = Inventory.instance;
        //Subscribing to Inventory Event
        _inventory.onBodyPartsChangedCallback += UpdateUI;

        _horde = Horde.instance;
        _horde.onHordeChangedCallback += UpdateUI;

        if (_horde.zombies.Count == 0)
            _horde.AddEmptyZombie();

        InitializeUI();
    }

    void InitializeUI()
    {
        _hordePanel.InitializeUI(_horde.zombies);
        _torsoTemplate.InitializeUI(_horde.GetSelectedZombie());
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
        _torsoTemplate.UpdateUI(_horde.GetSelectedZombie());
        foreach (var panel in _templatePanels)
        {
            panel.InitializeUI(_horde.GetSelectedZombie());
        }
        foreach (var panel in _bodyPartPanels)
        {
            panel.UpdateUI(_inventory.bodyParts);
        }
    }

    public void FoldAllBodyPartPanels()
    {
        foreach (var panel in _bodyPartPanels)
        {
            panel.ToggleBodyPartSlots(false);
        }
    }


    public void LoadLevelSeletionScreen()
    {
        if (_horde.zombies.Count <= 1 && _horde.zombies[0].currentBodyParts.Count <= 1)
        {
            Debug.Log("Can not start Level with 0 Zombies");
            return;
        }
        _horde.RemoveTorsoOnlyZombies();
        _inventory.onBodyPartsChangedCallback = null;
        _horde.onHordeChangedCallback = null;
        SceneManager.LoadScene("LevelSelection");
    }

    public void OnZombieAddButtonClicked()
    {
        _horde.AddEmptyZombie();
    }
}
