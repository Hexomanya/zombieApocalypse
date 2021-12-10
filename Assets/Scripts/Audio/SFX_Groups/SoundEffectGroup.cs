using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SoundEffectGroup", order = 1)]
public class SoundEffectGroup : ScriptableObject
{
    public float heighestPitch = 1.2f;
    public float lowestPitch = 0.8f;
    public float normalVolume = 1f;
    public float playChance = 1f;
    public AudioClip[] audioClips;
}
