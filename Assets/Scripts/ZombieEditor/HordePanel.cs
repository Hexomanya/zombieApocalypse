using System.Collections.Generic;
using UnityEngine;

public class HordePanel : MonoBehaviour
{
    public GameObject uiZombie;

    public void InitializeUI(List<BodyPartManager> zombies)
    {
        UpdateUI(zombies);
    }

    public void UpdateUI(List<BodyPartManager> zombies)
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
            var uiZombue = Instantiate(uiZombie, transform);
            uiZombie.GetComponent<UiZombieHandler>().bodyPartManager = zombie;
        }
    }

    public void ClearUI()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }

}
