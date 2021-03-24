using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public GameObject pausebox;
    private GameObject player;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pause();
            }
            else
            {
                resume();
            }
        }
    }
    public void pause()
    {
        player.GetComponent<player_control>().isPaused = isPaused;
        FindObjectOfType<SFX>().Play("button_pressed");
        Time.timeScale = 0f;
        pausebox.SetActive(true);
    }
    public void resume()
    {
        player.GetComponent<player_control>().isPaused = isPaused;
        FindObjectOfType<SFX>().Play("button_pressed");
        Time.timeScale = 1f;
        pausebox.SetActive(false);
    }

    public void setPause()
    {
        isPaused = !isPaused;
    }

}
