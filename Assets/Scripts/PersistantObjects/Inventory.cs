using System.Collections.Generic;
using UnityEngine;

//This class is a Singleton
//Get it by calling Inventory.instance
public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    
    public List<BodyPart> bodyParts = new List<BodyPart>();
    public List<BodyPart> newParts = new List<BodyPart>();

    public List<BodyPart> guaranteedBodyPartDropLevel0 = new List<BodyPart>();
    public List<BodyPart> guaranteedBodyPartDropLevel1 = new List<BodyPart>();
    public List<BodyPart> guaranteedBodyPartDropLevel2 = new List<BodyPart>();

    public delegate void OnBodyPartsChanged();
    public OnBodyPartsChanged onBodyPartsChangedCallback;

    private void Awake()
    {
        if (!GameManager.Instance.FirstEnterEditor)
        {
            return;
        }

        if (instance != null)
        {
            Debug.LogWarning("More then one Inventory instance has been found!");
            return;
        }
        DontDestroyOnLoad(this.transform.parent);
        instance = this;
    }

    public void AddNewBodyPart(BodyPart bodyPart)
    {
        newParts.Add(bodyPart);
        AddBodyPart(bodyPart);
    }

    public void AddBodyPart(BodyPart bodyPart)
    {
        bodyParts.Add(bodyPart);
        onBodyPartsChangedCallback?.Invoke();
    }

    public void RemoveBodyPart(BodyPart bodyPart)
    {
        bodyParts.Remove(bodyPart);
        onBodyPartsChangedCallback?.Invoke();
    }

    public int GetTotalAmountOfBodyPart(BodyPartType bodyPartType, ZombieType zombieType)
    {
        int amount = 0;
        foreach (var part in bodyParts)
        {
            if (part.type == bodyPartType && part.zombieType == zombieType)
                amount++;
        }
        return amount;
    }

    public int GetAmountOfNewBodyPart(BodyPartType bodyPartType, ZombieType zombieType)
    {
        int amount = 0;
        foreach (var part in newParts)
        {
            if (part.type == bodyPartType && part.zombieType == zombieType)
                amount++;
        }
        return amount;
    }

    public void AddGuaranteedBodyPartDrop(string levelName)
    {
        switch(levelName)
        {
            case "Level00":
                bodyParts.AddRange(guaranteedBodyPartDropLevel0);
                break;

            case "Level01":
                bodyParts.AddRange(guaranteedBodyPartDropLevel1);
                break;

            case "Level02":
                bodyParts.AddRange(guaranteedBodyPartDropLevel2);
                break;
        }
    }
}
