using System.Collections.Generic;
using UnityEngine;

//This class is a Singleton
//Get it by calling Inventory.instance
public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    
    public List<BodyPart> bodyParts = new List<BodyPart>();
    public List<BodyPart> newParts = new List<BodyPart>();

    public delegate void OnBodyPartsChanged();
    public OnBodyPartsChanged onBodyPartsChangedCallback;


    private void Awake()
    {
        if(instance != null)
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
}
