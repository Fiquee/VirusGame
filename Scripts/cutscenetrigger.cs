using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscenetrigger : MonoBehaviour
{
    public GameObject boss;
    public GameObject wall;
    private bool triggered;
    private void Start()
    {
        triggered = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggered == false)
            {
                triggered = true;
                Time.timeScale = 0f;
                wall.GetComponent<Animator>().SetTrigger("activate");
                wall.GetComponent<BoxCollider2D>().enabled = true;
            }
        }

    }

    public void startbossFight()
    {
        Time.timeScale = 1f;
        boss.GetComponent<Boss>().startfight();
    }
}
