using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenPopup : MonoBehaviour
{
    public void LevelWon()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void GameOver()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void ClickContinue()
    {
        GameManager.Instance.LoadLevelSeletionScreen();
    }

    public void OnReturnClicked()
    {
        Destroy(GameManager.Instance.gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
