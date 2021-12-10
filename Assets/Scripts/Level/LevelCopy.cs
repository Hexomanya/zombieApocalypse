using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCopy
{
    public string SceneName { get; private set; }
    public bool Completed { get; set; }
    public bool Locked { get; set; }
    public AudioClip LevelSoundtrack { get; private set; }

    public LevelCopy(string sceneName, bool completed, bool locked, AudioClip soundtrack)
    {
        this.SceneName = sceneName;
        this.Completed = completed;
        this.Locked = locked;
        this.LevelSoundtrack = soundtrack;
    }
}
