using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private string sceneName; //TODO: Do not use string
    [SerializeField] private bool locked = true;
    public bool Completed { get; set; }
    

    public bool Locked { get => locked; set => locked = value; }
    public string SceneName { get => sceneName; }
}
