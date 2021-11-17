using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{
    // Empty GameObject with a BodyPartManager Component
    public List<GameObject> zombies;

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

        zombies[SelectedIndex].GetComponent<BodyPartManager>().AttachBodyPart(bodyPart);
    }

    public BodyPartManager GetSelectedZombie()
    {
        if (zombies == null || zombies.Count <= SelectedIndex)
            return null;

        return zombies[SelectedIndex].GetComponent<BodyPartManager>();
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
            zombies = new List<GameObject>();
        }

        
        if (zombies.Count > 0)
        {
            // Do not add a new empty Zombie if the last Zombie in the List has no other BodyParts than a Torso
            var lastZombiesBodyParts = zombies[zombies.Count - 1].GetComponent<BodyPartManager>().currentBodyParts;
            if (lastZombiesBodyParts[0] == null && lastZombiesBodyParts[1] == null && lastZombiesBodyParts[3] == null && lastZombiesBodyParts[4] == null && lastZombiesBodyParts[5] == null)
            {
                // Last Zombie only has a Torso!
                Debug.Log("Can not add a zombie when the last one does not have BodyParts!");
                return;
            }
                
        }

        var newZombie = Instantiate(emptyBodyPartManager, transform);

        // Empty zombies can not exist, they need at least a torso
        // Not elegant, this approach offers room for improvement
        foreach (var bodyPart in availableBodyParts)
        {
            if (bodyPart.Type == BodyPartType.Torso)
            {
                newZombie.GetComponent<BodyPartManager>().currentBodyParts[(int)BodyPartType.Torso] = bodyPart;
            }
        }

        zombies.Add(newZombie);
        if (onHordeChangedCallback != null)
            onHordeChangedCallback.Invoke();
    }

}
