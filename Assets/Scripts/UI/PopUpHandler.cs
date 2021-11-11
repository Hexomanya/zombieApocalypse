using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpHandler : MonoBehaviour
{
    private bool buttonWasPressed = false;

    public void LocationButtonPressed()
    {
        buttonWasPressed = !buttonWasPressed;
        this.gameObject.SetActive(buttonWasPressed);
    }
}
