using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkradius : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<enemy2>().canshoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<enemy2>().canshoot = false;
        }
    }
}
