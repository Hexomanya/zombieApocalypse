using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessageHandler : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI textObject;
    [SerializeField] private Button buttonObject;

    private bool isActivated = false;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public bool ShowMessage(string message)
    {
        if (!isActivated)
        {
            textObject.text = message;

            this.gameObject.SetActive(true);
            isActivated = true;
        }
        else
        {
            Debug.LogWarning("Tried to show Popup Message, but another message was already displaying");
            return false;
        }

        return true;
    }

    public void OnCloseButtonClicked()
    {
        this.gameObject.SetActive(false);
        isActivated = false;
    }
}
