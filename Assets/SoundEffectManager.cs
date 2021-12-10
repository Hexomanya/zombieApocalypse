using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager Instance { get; private set; }

    public enum SoundEffect
    {
        ButtonPressed,
        Punch,
        PanickedScream,
        DoorBreaking,
        ZombieConfused,
        ZombieDeath,
        ZombieEngage,
        ZombieGrowl,
        PistolShot,
        PlayerCommand,
        GoreAttack
    }

    [Header("Sound Effect Groups:")]
    [SerializeField] private SoundEffectGroup buttonPressedGroup;
    [SerializeField] private SoundEffectGroup punchGroup;
    [SerializeField] private SoundEffectGroup panickedScreamGroup;
    [SerializeField] private SoundEffectGroup doorBreakingGroup;
    [SerializeField] private SoundEffectGroup zombieConfusedGroup;
    [SerializeField] private SoundEffectGroup zombieDeathGroup;
    [SerializeField] private SoundEffectGroup zombieEngageGroup;
    [SerializeField] private SoundEffectGroup zombieGrowlGroup;
    [SerializeField] private SoundEffectGroup pistolShotGroup;
    [SerializeField] private SoundEffectGroup playerCommandGroup;
    [SerializeField] private SoundEffectGroup goreAttackGroup;

    [Header("Zombie Growl Settings:")]
    [SerializeField] private float growlTimeout = 5f;

    private AudioSource audioSource;

    private float currentGrowlTimeout;
    private bool canPlayGrowl = true;

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
        currentGrowlTimeout = growlTimeout;
    }


    public void PlaySoundNo3D(SoundEffect effect, bool ignoreChance = true)
    {
        audioSource.spatialBlend = 0f;
        PlaySound(effect, audioSource, ignoreChance);
        audioSource.spatialBlend = 1f;
    }

    public void PlaySound(SoundEffect effect, Vector3 position)
    {
        Vector3 oldPos = this.transform.position;

        this.transform.position = position;
        PlaySound(effect, audioSource);
        this.transform.position = oldPos;
    }

    public void PlaySound(SoundEffect effect, AudioSource source, bool ignoreChance = false)
    {
        if(source == null) { 

            source = audioSource; 
        }

        SoundEffectGroup group = GetEffectGroup(effect);

        if(Random.Range(0, 1f) <= group.playChance || ignoreChance)
        {
            source.pitch = Random.Range(group.lowestPitch, group.heighestPitch);
            source.volume = group.normalVolume;

            AudioClip clipToPlay = group.audioClips[Random.Range(0, group.audioClips.Length - 1)];

            source.PlayOneShot(clipToPlay);
        }
    }
    
    public void PlayZombieGrowl(AudioSource source)
    {
        if (canPlayGrowl)
        {
            this.PlaySound(SoundEffect.ZombieGrowl, source);
            canPlayGrowl = false;
        }
    }

    private void Update()
    {
        if (currentGrowlTimeout <= 0)
        {
            canPlayGrowl = true;
            currentGrowlTimeout = growlTimeout;
        }
        else
        {
            currentGrowlTimeout -= Time.deltaTime;
        }
    }

    private SoundEffectGroup GetEffectGroup(SoundEffect effect)
    {
        switch (effect)
        {
            case SoundEffect.ButtonPressed:
                return buttonPressedGroup;

            case SoundEffect.Punch:
                return punchGroup;

            case SoundEffect.PanickedScream:
                return panickedScreamGroup;

            case SoundEffect.DoorBreaking:
                return doorBreakingGroup;

            case SoundEffect.ZombieConfused:
                return zombieConfusedGroup;

            case SoundEffect.ZombieDeath:
                return zombieDeathGroup;

            case SoundEffect.ZombieEngage:
                return zombieEngageGroup;

            case SoundEffect.ZombieGrowl:
                return zombieGrowlGroup;

            case SoundEffect.PistolShot:
                return pistolShotGroup;

            case SoundEffect.PlayerCommand:
                return playerCommandGroup;

            case SoundEffect.GoreAttack:
                return goreAttackGroup;
            default:
                return null;
        }
    }
}