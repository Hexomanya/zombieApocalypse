using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HordePanel : MonoBehaviour
{
    public GameObject uiZombie;

    private List<UiZombieHandler> uiZombies;


    public void InitializeUI(List<BodyPartManager> zombies)
    {
        uiZombies = new List<UiZombieHandler>();
        UpdateUI(zombies);
    }

    public void UpdateUI(List<BodyPartManager> zombies)
    {
        ClearUI();

        for(int i=0; i < zombies.Count; i++)
        {
            // Instantiate UiZombie with its BodyParts
            var currentZombie = Instantiate(uiZombie, transform);

            // Highlight selected Zombie
            if( i == Horde.instance.SelectedIndex)
            {
                var selectedUiZombieImage = currentZombie.GetComponent<Image>();
                selectedUiZombieImage.color = new Color(selectedUiZombieImage.color.r, selectedUiZombieImage.color.g, selectedUiZombieImage.color.b, 1);
            }
            var currentUiZombieHandler = currentZombie.GetComponent<UiZombieHandler>();
            currentUiZombieHandler.BodyPartManager = zombies[i];
            currentUiZombieHandler.Index = i;
            uiZombies.Add(currentUiZombieHandler);
        }

        foreach(var uiZombieHandler in uiZombies)
        {
            uiZombieHandler.UpdateUI();
        }
    }

    public void ClearUI()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
        uiZombies = new List<UiZombieHandler>();
    }
}
