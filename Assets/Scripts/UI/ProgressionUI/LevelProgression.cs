using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    public static LevelProgression instance;

    [SerializeField] private Level[] levels;

    private int currentLevel = 1;

    public Level[] Levels { get => levels; }

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
                Debug.Log("Tried to Unlock" + levels[currentLevel].name + ", without completing it.");
            }
        }
        else
        {
            if(!GameManager.Instance.AllLevelsComplete){
                bool allCompleted = true;

                foreach (Level level in Levels)
                {
                    if (!level.Completed) { allCompleted = false; }
                }

                GameManager.Instance.AllLevelsComplete = allCompleted;
            }
            

            if(GameManager.Instance.AllLevelsComplete) 
            {
                foreach (Level level in Levels)
                {
                    level.Locked = false;
                }
            }
        }
    }

    public Level GetLevelByName(string searchedName)
    {
        foreach (Level level in levels)
        {
            if(level.name == searchedName)
            {
                return level;
            }
        }

        Debug.LogWarning("GetLevelByName: Could not find level!");
        return null;
    }
}
