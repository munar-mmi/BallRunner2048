using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    public GameObject level, levelMenu, tapToPlay;
    public LevelManager levelManager;
    public int levelID;

    private GameObject levelObject;

    public void SelectLevel()
    {
        levelObject = Instantiate(level);
        levelObject.transform.position = new Vector3(0, 0, 0);
        levelManager.currentLevel = levelID;

        levelMenu.gameObject.SetActive(false);
        tapToPlay.gameObject.SetActive(true);
    }
}
