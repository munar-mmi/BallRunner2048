using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelsPrefab;
    public GameObject levelArr, levelMenu, tapToPlay, levelArea;
    public Button buttonPrefab;
    public List<Level> levels;
    public List<Button> levelButtons;

    private int currentLevel;

    void Start()
    {
        AddButton();

        OpenLevel();
    }

    public void OpenLevel()
    {
        for(int i = 0; i < levelButtons.Count - 1; i++)
        {
            if (!levels[i].isComplete)
            {
                levelButtons[i + 1].interactable = false;
            }
            else
            {
                levelButtons[i + 1].interactable = true;
            }
        }
    }

    public void NextLevel(Player player)
    {
        Level level = levels[currentLevel - 1];
        level.isComplete = true;
        if (level.levelScore < player.pointValue)
        {
            level.levelScore = player.pointValue;
        }
        if (level.levelStar < player.starValue)
        {
            level.levelStar = player.starValue;
        }
        OpenLevel();
        level.SaveLevel();
        level.ChangeLevelMenu();
    }

    void SelectLevel(Level level)
    {
        levelArea = Instantiate(level.levelPrefab);
        levelArea.transform.position = new Vector3(0, 0, 0);

        levelMenu.SetActive(false);
        tapToPlay.gameObject.SetActive(true);

        currentLevel = level.levelID;
    }

    public void AddButton()
    {
        for (int i = 1; i <= levelsPrefab.Length; i++)
        {
            Button levelButton = Instantiate(buttonPrefab);
            Level level = levelButton.gameObject.GetComponent<Level>();
            levelButton.transform.SetParent(levelArr.transform);

            levelButton.onClick.AddListener(delegate { SelectLevel(level); });

            level.levelID = i;
            level.name = i.ToString();
            level.GetComponentInChildren<TMP_Text>().text = i.ToString();
            level.levelPrefab = levelsPrefab[i - 1];
            level.levelManager = this;
            
            levels.Add(level);
            levelButtons.Add(levelButton);
        }
    }
}
