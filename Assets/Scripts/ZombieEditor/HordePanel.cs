using Assets.Scripts.Actors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordePanel : MonoBehaviour
{
    public GameObject uiZombie;

    public void InitializeUI(List<Actor> zombies)
    {
        UpdateUI(zombies);
    }

    public void UpdateUI(List<Actor> zombies)
    {
        ClearUI();
        if (zombies == null || zombies.Count == 0)
        {
            // Instantiate empty Zombie
            Instantiate(uiZombie, transform);
            return;
        }

        foreach (var zombie in zombies)
        {
            // Instantiate Zombie with its BodyParts
            Instantiate(uiZombie, transform);
        }
    }

    public void ClearUI()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }

}
