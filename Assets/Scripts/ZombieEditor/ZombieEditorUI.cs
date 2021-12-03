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
        _horde.SelectedIndex = 0;
        _horde.onHordeChangedCallback += UpdateUI;

        if (_horde.zombies.Count == 0)
            _horde.AddEmptyZombie();

        InitializeUI();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.LoadLevelSeletionScreen();
        }
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

    public void OnZombieAddButtonClicked()
    {
        _horde.AddEmptyZombie();
    }

    public void FoldAllBodyPartPanels()
    {
        foreach (var panel in _bodyPartPanels)
        {
            panel.ToggleBodyPartSlots(false);
        }
    }

    public void OnStartGameButtonClicked()
    {
        //Do animations here
        GameManager.Instance.LoadNextLevel();
    }
}
