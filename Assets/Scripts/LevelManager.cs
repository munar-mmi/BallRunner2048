using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;
    public Level[] levels;
    public LevelMenuController[] levelMenuControllers;
    public int currentLevel;

    public void OpenLevel()
    {
        for (int i = 0; i < levels.Length - 1; i++)
        {
            if (levels[i].isComplete)
            {
                levelButtons[i + 1].interactable = true;
            }
        }

        for (int i = 0; i < levels.Length; i++)
        { 
            levelMenuControllers[i].ChangeLevelMenu(levels[i].levelStar); 
        }
    }

    public void NextLevel(int pointValue, int starValue)
    {
        Level level = levels[currentLevel - 1];
        level.isComplete = true;
        if(level.levelScore < pointValue)
        {
            level.levelScore = pointValue;
        }
        if(level.levelStar < starValue)
        {
            level.levelStar = starValue;
        }
        OpenLevel();
        level.SaveLevel();
    }
}