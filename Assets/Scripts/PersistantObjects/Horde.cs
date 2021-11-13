using Assets.Scripts.Actors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{
    public List<BodyPartManager> zombies;

    public static Horde instance;

    public delegate void OnHordeChanged();
    public OnHordeChanged onHordeChangedCallback;

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

    public BodyPartManager GetSelectedZombie()
    {
        if (zombies == null || SelectedIndex > zombies.Count)
            return null;

        return zombies[SelectedIndex];
    }

    public void AddZombie(BodyPartManager zombie)
    {
        zombies.Add(zombie);
        if (onHordeChangedCallback != null)
            onHordeChangedCallback.Invoke();
    }

    public void AddEmptyZombie()
    {
        AddZombie(new BodyPartManager());
    }

    public void RemoveZombie(BodyPartManager zombie)
    {
        zombies.Remove(zombie);
        if (onHordeChangedCallback != null)
            onHordeChangedCallback.Invoke();
    }
}
