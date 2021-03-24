using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        FindObjectOfType<SFX>().Play("button_pressed");
        Application.Quit();
    }
}
