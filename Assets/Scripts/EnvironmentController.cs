using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public enum envTypes { Death, LevelFinal };
    public envTypes envType;
    public GameObject winMenu, looseMenu;

    public LevelManager levelManager;
    public LevelMenuController levelMenu;
    public Point playerObject;

    void OnCollisionEnter(Collision collision)
    {
        Point player = collision.gameObject.GetComponent<Point>();
        if (player == playerObject)
        {
            if (envType.HasFlag(envTypes.LevelFinal))
            {
                winMenu.SetActive(true);

                levelManager.NextLevel();

                playerObject.GameOver();
            }
            else if (envType.HasFlag(envTypes.Death))
            {
                playerObject.GameOver();
                looseMenu.SetActive(true);
            }
        }
    }
}
