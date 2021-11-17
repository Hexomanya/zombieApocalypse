using UnityEngine;

public class EndScreenPopup : MonoBehaviour
{
    public void LevelEnded()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ClickContinue()
    {
        GameManager.Instance.LoadEditorScene();
    }
}
