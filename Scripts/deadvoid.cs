using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadvoid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "enemy")
        {
            Destroy(obj.gameObject);
        }
    }
}
