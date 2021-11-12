using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class LevelSelectHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> disableOnStart = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject item in disableOnStart)
        {
            item.SetActive(false);
        }
    }
    public void LevelSelectButtonPressed(string sceneName)
    {
        switch (sceneName)
        {
            case "Level01":
                Debug.Log("Level 1 Loaded");
                //SceneManager.LoadScene("Level01");
                break;
            case "Level02":
                Debug.Log("Level 1 Loaded");
                //SceneManager.LoadScene("Level02");
                break;
            case "Level03":
                Debug.Log("Level 1 Loaded");
                //SceneManager.LoadScene("Level03");
                break;

            default:
                break;
        }
    }
}
