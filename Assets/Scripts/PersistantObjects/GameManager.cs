using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private static string selectedLevel;
    public bool FirstEnterSelection { get; set; } = true;
    public bool FirstEnterEditor { get; set; } = true;
    public bool FirstEnterLevel { get; set; } = true;
    public bool AllLevelsComplete { get; set; } = false;

    public float BodyPartDropChance = 0.1f;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void LoadEditorScene(string nextSceneName)
    {
        selectedLevel = nextSceneName;

        if(Inventory.instance != null)
        {
            Inventory.instance.newParts.Clear();
        }
        
        SceneManager.LoadScene("ZombieEditor");
    }

    public void LoadLevelSeletionScreen()
    {
        if (LevelProgression.instance != null)
        {
            LevelProgression.instance.UnlockNextLevel();
        }

        SceneManager.LoadScene("LevelSelection");
    }

    public void LoadNextLevel()
    {
        if(selectedLevel != null)
        {
            if (Horde.instance.zombies.Count <= 1 && Horde.instance.zombies[0].currentBodyParts.Count <= 1)
            {
                Debug.LogWarning("Can not start Level with 0 Zombies");
                return;
            }
            Horde.instance.RemoveTorsoOnlyZombies();
            Inventory.instance.onBodyPartsChangedCallback = null;
            Horde.instance.onHordeChangedCallback = null;

            SceneManager.LoadScene(selectedLevel);
        }
        else
        {
            Debug.LogError("SelectedLevel is undefined!");
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
