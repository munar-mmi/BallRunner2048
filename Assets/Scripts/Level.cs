using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int levelID;
    public int levelScore;
    public int levelStar;
    public bool isComplete;

    public void Start()
    {
        LoadLevel();
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
