using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private static string selectedLevel;
    public static bool FirstEnterSelection { get; set; } = true;
    public static bool FirstEnterEditor { get; set; } = true;
    public static bool FirstEnterLevel { get; set; } = true;
    public static bool AllLevelsComplete { get; set; } = false;

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
            Inventory.instance.onBodyPartsChangedCallback = null;
            Horde.instance.onHordeChangedCallback = null;

            SceneManager.LoadScene(selectedLevel);
        }
        else
        {
            Debug.LogError("SelectedLevel is undefined!");
        }
    }
}
