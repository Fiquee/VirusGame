using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyborder : MonoBehaviour
{
    private bool onelevator;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "enemy")
        {
            obj.GetComponent<enemy>().waitandchangedir();
        }
    }
}
