using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TutorialManager : MonoBehaviour
{
    private enum TutorialTypes { Selection, Editor, Level}

    [SerializeField] private TutorialTypes type;
    private void Awake()
    {
        this.gameObject.SetActive(CheckShowTutorial());
    }

    private bool CheckShowTutorial()
    {
        switch (this.type)
        {
            case TutorialTypes.Selection:
                return GameManager.FirstEnterSelection;
            case TutorialTypes.Editor:
                return GameManager.FirstEnterEditor;
            case TutorialTypes.Level:
                return GameManager.FirstEnterLevel;
        }

        return false;
    }

    private void SetFirstEnter()
    {
        switch (this.type)
        {
            case TutorialTypes.Selection:
                GameManager.FirstEnterSelection = false;
                break;
            case TutorialTypes.Editor:
                GameManager.FirstEnterEditor = false;
                break;
            case TutorialTypes.Level:
                GameManager.FirstEnterLevel = false;
                break;
        }
    }

    public void OnContinueButtonClicked()
    {
        SetFirstEnter();
        Destroy(this.gameObject);
    }
}
