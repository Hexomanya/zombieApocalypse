using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{
    public List<Zombie> zombies;

    public Zombie zombie;

    void Awake()
    {
        zombies = new List<Zombie>();
        zombies.Add(zombie);
        zombies.Add(zombie);
        zombies.Add(zombie);
    }

    void Start()
    {
       
    }

    void Update()
    {
        
    }
}
