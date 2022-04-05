using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlayController : MonoBehaviour
{
    public GameObject player, cameraObject, tapToPlay, menuContainer;

    public void TapToPlay()
    {
        tapToPlay.SetActive(false);
        menuContainer.SetActive(false);

        player.SetActive(true);
        player.transform.position = new Vector3(0, 2, 0);
        cameraObject.transform.position = new Vector3(0, 8, -10);
    }
}
