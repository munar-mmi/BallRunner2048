using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu, levelMenu;

    public void SelectLevel()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
