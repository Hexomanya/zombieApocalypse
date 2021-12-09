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
        ZombieEngage,
        PistolShot,
        GoreAttack
    }

    [Header("Sound Effect Groups:")]
    [SerializeField] SoundEffectGroup punchGroup;
    [SerializeField] SoundEffectGroup panickedScreamGroup;
    [SerializeField] SoundEffectGroup doorBreakingGroup;
    [SerializeField] SoundEffectGroup zombieDeathGroup;
    [SerializeField] SoundEffectGroup zombieEngageGroup;
    [SerializeField] SoundEffectGroup pistolShotGroup;
    [SerializeField] SoundEffectGroup goreAttackGroup;

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
    public void PlaySound(SoundEffect effect, Vector3 position)
    {
        Vector3 oldPos = this.transform.position;

        this.transform.position = position;
        PlaySound(effect, audioSource);
        this.transform.position = oldPos;
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
            source.volume = group.normalVolume;

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

            case SoundEffect.PistolShot:
                return pistolShotGroup;

            case SoundEffect.GoreAttack:
                return goreAttackGroup;
            default:
                return null;
        }
    }
}