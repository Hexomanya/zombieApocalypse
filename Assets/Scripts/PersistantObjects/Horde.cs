using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{
    // Empty GameObject with a BodyPartManager Component
    public List<BodyPartManager> zombies;

    public GameObject emptyBodyPartManager;

    public static Horde instance;

    public delegate void OnHordeChanged();
    public OnHordeChanged onHordeChangedCallback;

    // Not elegant, this approach offers room for improvement
    public List<BodyPart> availableBodyParts;

    public int SelectedIndex { get; set; }  = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More then one Horde instance has been found!");
            return;
        }
        instance = this;
    }


    /// <returns>True if BodyPart was attached successfully, else false</returns>
    public bool AttachBodyPartToSelectedZombie(BodyPart bodyPart)
    {
        if (zombies == null || zombies.Count <= SelectedIndex)
            return false;

        return zombies[SelectedIndex].AttachBodyPart(bodyPart);
    }


    public BodyPartManager GetSelectedZombie()
    {
        if (zombies == null || zombies.Count <= SelectedIndex)
            return null;

        return zombies[SelectedIndex];
    }

    public void SetSelectedZombie(int index)
    {
        if (SelectedIndex != index)
        {
            SelectedIndex = index;
            if (onHordeChangedCallback != null)
                onHordeChangedCallback.Invoke();
        }
    }

    public void AddEmptyZombie()
    {
        if (zombies == null)
        {
            zombies = new List<BodyPartManager>();
        }

        
        if (zombies.Count > 0)
        {
            // Do not add a new empty Zombie if the last Zombie in the List has no other BodyParts than a Torso
            if(zombies[zombies.Count - 1].currentBodyParts.Count == 1)
            {
                // Last Zombie only has a Torso!
                Debug.Log("Can not add a zombie when the last one does not have BodyParts!");
                return;
            }
                
        }

        var newZombie = Instantiate(emptyBodyPartManager, transform).GetComponent<BodyPartManager>();

        // Empty zombies can not exist, they need at least a torso
        // Not elegant, this approach offers room for improvement
        List<BodyPart> allTorsos = new List<BodyPart>();
        foreach (var bodyPart in availableBodyParts)
        {
            if (bodyPart != null && bodyPart.type == BodyPartType.Torso)
            {
                allTorsos.Add(bodyPart);
            }
        }

        // Give new Zombie a Random Torso
        newZombie.AttachBodyPart(allTorsos[Random.Range(0, allTorsos.Count)]);

        zombies.Add(newZombie);
        SelectedIndex = zombies.Count - 1;
        onHordeChangedCallback?.Invoke();
    }

    public void RemoveTorsoOnlyZombies()
    {
        for (int i = 0; i < zombies.Count; i++)
        {
            if (zombies[i].currentBodyParts.Count <= 1)
                zombies.RemoveAt(i);
        }
    }

}
