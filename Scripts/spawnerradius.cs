using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerradius : MonoBehaviour
{

    private float timecounter;
    private float time = 1f;

    private void Start()
    {
        timecounter = time;
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         GetComponentInParent<virusSpawner>().startspawning();
    //     }
    // }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timecounter > 0f)
            {
                timecounter -= Time.deltaTime;
            }
            else if (timecounter <= 0)
            {
                GetComponentInParent<virusSpawner>().startspawning();
                timecounter = time;
            }
        }
    }
}
