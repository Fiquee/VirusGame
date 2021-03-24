using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeButton : MonoBehaviour
{

    public GameObject pausemanager;
    public void resume()
    {
        pausemanager.GetComponent<PauseScript>().setPause();
        pausemanager.GetComponent<PauseScript>().resume();
    }
}
