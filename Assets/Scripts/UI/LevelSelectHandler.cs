using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class LevelSelectHandler : MonoBehaviour
{
    public void LevelSelectButtonPressed(string sceneName)
    {
        switch (sceneName)
        {
            case "Level00":
                Debug.Log("Level 0 Loaded");
                SceneManager.LoadScene("Level00");
                break;
            case "Level01":
                Debug.Log("Level 1 Loaded");
                SceneManager.LoadScene("Level01");
                break;
            case "Level02":
                Debug.Log("Level 1 Loaded");
                SceneManager.LoadScene("Level02");
                break;
            case "Level03":
                Debug.Log("Level 1 Loaded");
                SceneManager.LoadScene("Level03");
                break;

            default:
                break;
        }
    }
}
