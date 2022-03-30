using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    public int levelID;

    public GameObject level, levelMenu, tapToPlay;
    public LevelManager levelManager;
    public Image[] levelStars;
    public EnvironmentController levelFinal;

    private GameObject levelObject;

    public void ChangeLevelMenu(int starValue)
    {
        for(int i = 0; i < starValue; i++)
        {
            levelStars[i].GetComponent<Image>().color = new Color(255, 255, 0, 255);
        }
    }

    public void SelectLevel()
    {
        levelObject = Instantiate(level);
        levelObject.transform.position = new Vector3(0, 0, 0);
        levelManager.currentLevel = levelID;

        levelMenu.gameObject.SetActive(false);
        tapToPlay.gameObject.SetActive(true);
    }
}
