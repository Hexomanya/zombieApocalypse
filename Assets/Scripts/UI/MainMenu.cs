using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        //Do Animation or something here
        GameManager.Instance.LoadLevelSeletionScreen();
    }

    public void QuitButtonPressed()
    {
        Debug.Log("Game would be quitting, if not in editor!");
        Application.Quit();
    }
}
