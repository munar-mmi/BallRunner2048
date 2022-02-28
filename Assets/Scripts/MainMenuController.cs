using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu, levelMenu;

    public void SelectLevel()
    {
        mainMenu.gameObject.SetActive(false);
        levelMenu.gameObject.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
