using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    public static LevelProgression instance;

    [SerializeField] private LevelList levelList;

    private LevelCopy[] levels;
    private int currentLevel = 1;

    public LevelCopy[] Levels { get => levels; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More then one Level Progression System found!");
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        levels = new LevelCopy[levelList.levelList.Length];

        //Copy Levels so it doesn't get permantly saved; TODO: Costructor?
        for(int i = 0; i < levels.Length; i++)
        {
            LevelCopy l = new LevelCopy(
                levelList.levelList[i].SceneName,
                levelList.levelList[i].Completed,
                levelList.levelList[i].Locked,
                levelList.levelList[i].LevelSoundtrack
            );


            levels[i] = l;
        }

        if(levels.Length > 0)
        {
            levels[0].Locked = false;
        }
    }

    public void UnlockNextLevel()
    {
        //Only called for the second level
        if(currentLevel < levels.Length )
        {
            if (levels[currentLevel-1].Completed)
            {
                levels[currentLevel - 1].Locked = true;
                levels[currentLevel].Locked = false;
                currentLevel++;
            }
            else
            {
                Debug.Log("Tried to Unlock Level: " + levels[currentLevel].SceneName + ", without completing it.");
            }
        }
        else
        {
            if(!GameManager.Instance.AllLevelsComplete){
                bool allCompleted = true;

                foreach (LevelCopy level in Levels)
                {
                    if (!level.Completed) { allCompleted = false; }
                }

                GameManager.Instance.AllLevelsComplete = allCompleted;
            }
            

            if(GameManager.Instance.AllLevelsComplete) 
            {
                foreach (LevelCopy level in Levels)
                {
                    level.Locked = false;
                }
            }
        }
    }

    public LevelCopy GetLevelByName(string searchedName)
    {
        foreach (LevelCopy level in levels)
        {
            if(level.SceneName == searchedName)
            {
                return level;
            }
        }

        Debug.LogWarning("GetLevelByName: Could not find level!");
        return null;
    }
}
