using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkplayerelevator : MonoBehaviour
{
    private bool goback;
    private void Start()
    {
        goback = GetComponentInParent<elevator>().goback;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<elevator>().movetotarget();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!goback)
        {
            if (other.CompareTag("Player"))
            {
                GetComponentInParent<elevator>().movetostart();
            }
        }
    }
}
