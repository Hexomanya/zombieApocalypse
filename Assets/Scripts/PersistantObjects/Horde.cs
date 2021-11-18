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

    public void AttachBodyPartToSelectedZombie(BodyPart bodyPart)
    {
        if (zombies == null || zombies.Count <= SelectedIndex)
            return;

        zombies[SelectedIndex].AttachBodyPart(bodyPart);
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
        foreach (var bodyPart in availableBodyParts)
        {
            if (bodyPart != null && bodyPart.Type == BodyPartType.Torso)
            {
                newZombie.AttachBodyPart(bodyPart);
            }
        }

        zombies.Add(newZombie);
        if (onHordeChangedCallback != null)
            onHordeChangedCallback.Invoke();
    }

}
