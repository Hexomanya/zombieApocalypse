using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class LevelSelectHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.LoadMainMenu();
        }
    }

    public void LevelSelectButtonPressed(string sceneName)
    {
        //Do Animations Here
        GameManager.Instance.LoadEditorScene(sceneName);
    }
}
