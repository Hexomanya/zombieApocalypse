using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TutorialManager : MonoBehaviour
{
    private enum TutorialTypes { Selection, Editor, Level}

    [SerializeField] private TutorialTypes type;
    private void Awake()
    {
        bool shouldShowTutorial = CheckShowTutorial();

        this.gameObject.SetActive(shouldShowTutorial);

        if (shouldShowTutorial)
        {
            Time.timeScale = 0f;
        }
    }

    private bool CheckShowTutorial()
    {
        switch (this.type)
        {
            case TutorialTypes.Selection:
                return GameManager.Instance.FirstEnterSelection;
            case TutorialTypes.Editor:
                return GameManager.Instance.FirstEnterEditor;
            case TutorialTypes.Level:
                return GameManager.Instance.FirstEnterLevel;
        }

        return false;
    }

    private void SetFirstEnter()
    {
        switch (this.type)
        {
            case TutorialTypes.Selection:
                GameManager.Instance.FirstEnterSelection = false;
                break;
            case TutorialTypes.Editor:
                GameManager.Instance.FirstEnterEditor = false;
                break;
            case TutorialTypes.Level:
                GameManager.Instance.FirstEnterLevel = false;
                break;
        }
    }

    public void OnContinueButtonClicked()
    {
        SoundEffectManager.Instance.PlaySoundNo3D(SoundEffectManager.SoundEffect.ButtonPressed);

        SetFirstEnter();

        Time.timeScale = 1f;

        Destroy(this.gameObject);
    }
}
