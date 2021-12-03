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
        SetFirstEnter();
        Destroy(this.gameObject);
    }
}
