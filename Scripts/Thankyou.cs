using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thankyou : MonoBehaviour
{
    public GameObject scene_manager;
    public void finish()
    {
        scene_manager.GetComponent<SceneTransitions>().backtoMainMenu();
    }
}
