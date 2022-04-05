using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public enum envTypes { Death, LevelFinal };
    public envTypes envType;
    public GameObject menuContainer, winMenu, looseMenu;
    public Player playerObject;
    public LevelManager levelManager;

    void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player == playerObject)
        {
            if (envType == envTypes.LevelFinal)
            {
                winMenu.SetActive(true);
                menuContainer.SetActive(true);

                levelManager.NextLevel(player);
                playerObject.GameOver(levelManager.levelArea);
            }
            else if (envType == envTypes.Death)
            {
                playerObject.GameOver(levelManager.levelArea);
                looseMenu.SetActive(true);
            }
        }
    }
}
