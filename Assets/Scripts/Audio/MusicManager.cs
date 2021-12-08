using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField] private LevelList levelList;
    [SerializeField] private AudioClip menuMusic;

    private Level[] levels;
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

        levels = levelList.levelList;
        audioSource = this.GetComponent<AudioSource>();
    }

    private void OnLevelChanged(Scene scene, LoadSceneMode mode)
    {
        //Check if scene is in list
        foreach (Level level in levels)
        {
            if(level.SceneName == scene.name)
            {
                audioSource.clip = level.LevelSoundtrack;
                audioSource.Play();
                return;
            }
        }

        //If not a level
        audioSource.clip = this.menuMusic;
        audioSource.Play();
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
