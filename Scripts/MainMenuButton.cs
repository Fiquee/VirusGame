using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{

    public void returnToMainMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("GM"));
        FindObjectOfType<SFX>().Play("button_pressed");
        Time.timeScale = 1f;
        SFX.instance.islevel = false;
        SceneManager.LoadScene("MainMenu");
    }
}
