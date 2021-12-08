using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class LevelSelectHandler : MonoBehaviour
{
    [SerializeField] private PopUpMessageHandler messageHandler;

    private bool escapeMessageWasShown = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escapeMessageWasShown)
            {
                GameManager.Instance.LoadMainMenu();
            }
            else
            {
                messageHandler.ShowMessage("If you return to the main menu, all progress will be lost! Press the Escape-Key again if you still want to return to the main menu.");
                escapeMessageWasShown = true;
            }
        }
    }

    public void LevelSelectButtonPressed(string sceneName)
    {
        //Do Animations Here
        GameManager.Instance.LoadEditorScene(sceneName);
    }
}
