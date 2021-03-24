using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    private GameObject bigvirus;
    private Animator checkpointanim;
    private bool activate;

    private void Start()
    {
        checkpointanim = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!activate)
            {
                FindObjectOfType<SFX>().Play("player_hitcheckpoint");
                activate = true;
                checkpointanim.SetTrigger("activate");

                bigvirus = GameObject.Find("bigvirus");
                if (bigvirus != null)
                {
                    gm.setbigvirusposition(transform.position.x - 44f, 13.6f);
                }
                gm.setposition(transform.position);
            }
        }
    }
}
