using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpHandler : MonoBehaviour
{
    [SerializeField] private PopUpMessageHandler messageHandler;
    [SerializeField] private bool hideOnStart = true;
    private bool buttonWasPressed = false;
    private bool activated = true;

    private void Start()
    {
        if(GameManager.Instance.FirstEnterSelection && !hideOnStart) 
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void LocationButtonPressed()
    {
        if (activated)
        {
            buttonWasPressed = !buttonWasPressed;
            this.gameObject.SetActive(buttonWasPressed);
        }
        else
        {
            messageHandler.ShowMessage("You already killed all suvivors here! You first have to complete all other levels, to be able to play old ones again!");
        }
    }

    public void Deactivate()
    {
        //Later grey out instead of simplyblock;
        activated = false;
    }
}
