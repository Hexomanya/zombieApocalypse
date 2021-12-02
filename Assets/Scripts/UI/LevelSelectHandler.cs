using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class LevelSelectHandler : MonoBehaviour
{
    public void LevelSelectButtonPressed(string sceneName)
    {
        //Do Animations Here
        GameManager.Instance.LoadEditorScene(sceneName);
    }
}
