using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitioncontrol : MonoBehaviour
{

    public void releaseplayer()
    {
        Time.timeScale = 1f;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<player_control>().startmove();
    }

    public void stopAll()
    {
        Time.timeScale = 0f;
    }
}
