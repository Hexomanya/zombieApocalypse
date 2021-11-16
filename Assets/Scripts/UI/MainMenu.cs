using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        Debug.Log("Zombie Editor loaded");
        SceneManager.LoadScene("ZombieEditor");
    }

    public void QuitButtonPressed()
    {
        Debug.Log("Game would be quitting, if not in editor!");
        Application.Quit();
    }
}
