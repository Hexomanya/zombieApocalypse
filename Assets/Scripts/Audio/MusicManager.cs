using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [Header("General Settings:")]
    [SerializeField] private LevelList levelList;
    [SerializeField] private AudioClip menuMusic;

    [Header("Audio Settings:")]
    [SerializeField] private float audioFadeTime = 1f;

    private Level[] levels;
    private AudioSource audioSource;

    private AudioClip currentAudioClip;
    private AudioClip switchToAudioClip;

    private bool isSwitchingTracks;
    private float currentFadeTime;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);

        levels = levelList.levelList;
        audioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Check if currently Fade out
        if(isSwitchingTracks && switchToAudioClip != null)
        {
            //Fade out
            currentFadeTime -= Time.deltaTime;
            audioSource.volume = currentFadeTime / audioFadeTime;

            //Switch tracks if silent
            if(currentFadeTime <= 0)
            {
                audioSource.volume = 0;

                audioSource.clip = switchToAudioClip;
                audioSource.Play();

                currentAudioClip = switchToAudioClip;
                switchToAudioClip = null;

                currentFadeTime = 0;
            }
        }
        //Check if currently fade in
        else if(isSwitchingTracks && switchToAudioClip == null)
        {
            //Fade in
            currentFadeTime += Time.deltaTime;
            audioSource.volume = currentFadeTime / audioFadeTime;

            if(currentFadeTime >= audioFadeTime)
            {
                currentFadeTime = audioFadeTime;
                audioSource.volume = 1f;

                isSwitchingTracks = false;
            }
        }
        
    }

    private void OnLevelChanged(Scene scene, LoadSceneMode mode)
    {
        AudioClip levelAudioClip;

        levelAudioClip = GetLevelAudioClip(scene.name);

        if(levelAudioClip != currentAudioClip)
        {
            switchToAudioClip = levelAudioClip;
            isSwitchingTracks = true;
        }
    }

    private AudioClip GetLevelAudioClip(string sceneName)
    {
        //Check if scene is in list
        foreach (Level level in levels)
        {
            if (level.SceneName == sceneName)
            {
                return level.LevelSoundtrack;
            }
        }

        //If not a level
        return this.menuMusic;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelChanged;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelChanged;
    }
}
