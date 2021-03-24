using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{

    public GameObject scene_manager;
    public void StartGame()
    {
        FindObjectOfType<SFX>().Play("button_pressed");
        SFX.instance.mainmenu = false;
        scene_manager.GetComponent<SceneTransitions>().playlevel();
    }
}
