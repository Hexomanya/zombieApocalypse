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
        GoreAttack,
        BodyPartCollected
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
    [SerializeField] private SoundEffectGroup bodyPartCollectedGroup;

    [Header("Zombie Growl Settings:")]
    [SerializeField] private float growlTimeout = 5f;

    [Header("Zombie Engage Settings:")]
    [SerializeField] private float engageTimeout = 2.5f;

    [Header("Player command Settings:")]
    [SerializeField] private float commandTimeout = 0.5f;

    private AudioSource audioSource;

    private float currentGrowlTimeout;
    private float currentEngageTimeout;
    private float currentCommandTimeout;
    private bool canPlayGrowl = true;
    private bool canPlayEngage = true;
    private bool canPlayCommand = true;

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
        if(effect == SoundEffect.ZombieEngage && !canPlayEngage) { return; }
        if (effect == SoundEffect.PlayerCommand && !canPlayCommand) { return; }

        if (source == null) { 

            source = audioSource; 
        }

        SoundEffectGroup group = GetEffectGroup(effect);

        if(Random.Range(0, 1f) <= group.playChance || ignoreChance)
        {
            source.pitch = Random.Range(group.lowestPitch, group.heighestPitch);
            source.volume = group.normalVolume;

            AudioClip clipToPlay = group.audioClips[Random.Range(0, group.audioClips.Length - 1)];

            if (effect == SoundEffect.ZombieEngage) { Debug.Log("Playing engage"); canPlayEngage = false; }
            if (effect == SoundEffect.PlayerCommand) { canPlayCommand = false; }

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

        if (currentEngageTimeout <= 0)
        {
            canPlayEngage = true;
            currentEngageTimeout = engageTimeout;
        }
        else
        {
            currentEngageTimeout -= Time.deltaTime;
        }

        if (currentCommandTimeout <= 0)
        {
            canPlayCommand = true;
            currentCommandTimeout = commandTimeout;
        }
        else
        {
            currentCommandTimeout -= Time.deltaTime;
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

            case SoundEffect.BodyPartCollected:
                return bodyPartCollectedGroup;

            default:
                return null;
        }
    }
}