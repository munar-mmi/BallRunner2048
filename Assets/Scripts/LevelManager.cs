using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;
    public int currentLevel;

    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        NextLevel();
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel++);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < currentLevel)
            {
                levelButtons[i].interactable = true;
            }
        }
    }
}
