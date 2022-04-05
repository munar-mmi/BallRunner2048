using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    public int levelID, levelScore, levelStar;
    public bool isComplete;

    public GameObject levelPrefab;
    public LevelManager levelManager;

    public void Start()
    {
        LoadLevel();
        ChangeLevelMenu();
    }

    public void ChangeLevelMenu()
    {
        for (int i = 0; i < levelStar; i++)
        {
            Star[] stars = GetComponentsInChildren<Star>();
            stars[i].GetComponent<Image>().color = new Color(255, 255, 0, 255);
        }
        levelManager.OpenLevel();
    }

    public void SaveLevel()
    {
        SaveSystem.SaveData(this);
    }

    public void LoadLevel()
    {
        LevelData data = SaveSystem.LoadData(this);

        levelScore = data.levelScore;
        levelStar = data.levelStar;
        isComplete = data.isComplete;
    }
}