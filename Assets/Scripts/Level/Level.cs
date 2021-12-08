using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Level", order = 1)]
public class Level : ScriptableObject
{
    [SerializeField] private string sceneName; //TODO: Do not use string
    [SerializeField] private bool locked = true;
    [SerializeField] private AudioClip levelSoundtrack;
    public bool Completed { get; set; }
    public bool Locked { get => locked; set => locked = value; }
    public string SceneName { get => sceneName; }
    public AudioClip LevelSoundtrack { get => levelSoundtrack; }
}
