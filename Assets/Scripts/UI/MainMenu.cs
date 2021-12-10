using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        //Do Animation or something here
        SoundEffectManager.Instance.PlaySoundNo3D(SoundEffectManager.SoundEffect.ButtonPressed);

        GameManager.Instance.LoadLevelSeletionScreen();
    }

    public void QuitButtonPressed()
    {
        SoundEffectManager.Instance.PlaySoundNo3D(SoundEffectManager.SoundEffect.ButtonPressed);

        Debug.Log("Game would be quitting, if not in editor!");
        Application.Quit();
    }
}
