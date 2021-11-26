using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpHandler : MonoBehaviour
{
    [SerializeField] private bool hideOnStart = true;
    private bool buttonWasPressed = false;

    private void Start()
    {
        this.gameObject.SetActive(!hideOnStart);
    }

    public void LocationButtonPressed()
    {
        buttonWasPressed = !buttonWasPressed;
        this.gameObject.SetActive(buttonWasPressed);
    }
}
