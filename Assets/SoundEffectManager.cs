using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager Instance { get; private set; }

    public enum SoundEffect
    {
        Punch,
        PanickedScream,
        DoorBreaking,
        ZombieDeath,
        ZombieEngage
    }

    [Header("Sound Effect Groups:")]
    [SerializeField] SoundEffectGroup punchGroup;
    [SerializeField] SoundEffectGroup panickedScreamGroup;
    [SerializeField] SoundEffectGroup doorBreakingGroup;
    [SerializeField] SoundEffectGroup zombieDeathGroup;
    [SerializeField] SoundEffectGroup zombieEngageGroup;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);

        audioSource = this.GetComponent<AudioSource>();
    }

    //TODO: Cleaner
    public void PlaySound(SoundEffect effect)
    {
        PlaySound(effect, audioSource);
    }
    //TODO: Cleaner
    public void PlaySound(SoundEffect effect, Vector3 position, float volume = 1f)
    {
        Vector3 oldPos = this.transform.position;
        float oldVolume = audioSource.volume;

        this.transform.position = position;
        audioSource.volume = volume;

        PlaySound(effect, audioSource);

        this.transform.position = oldPos;
        audioSource.volume = oldVolume;
    }

    public void PlaySound(SoundEffect effect, AudioSource source)
    {
        if(source == null) { 

            source = audioSource; 
        }

        SoundEffectGroup group = GetEffectGroup(effect);

        if(Random.Range(0, 1f) <= group.playChance)
        {
            source.pitch = Random.Range(group.lowestPitch, group.heighestPitch);
            AudioClip clipToPlay = group.audioClips[Random.Range(0, group.audioClips.Length - 1)];

            source.PlayOneShot(clipToPlay);
        }
    }

    private SoundEffectGroup GetEffectGroup(SoundEffect effect)
    {
        switch (effect)
        {
            case SoundEffect.Punch:
                return punchGroup;

            case SoundEffect.PanickedScream:
                return panickedScreamGroup;

            case SoundEffect.DoorBreaking:
                return doorBreakingGroup;

            case SoundEffect.ZombieDeath:
                return zombieDeathGroup;

            case SoundEffect.ZombieEngage:
                return zombieEngageGroup;

            default:
                return null;
        }
    }
}