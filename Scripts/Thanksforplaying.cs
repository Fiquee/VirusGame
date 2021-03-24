using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thanksforplaying : MonoBehaviour
{
    public GameObject knob;
    private void Start()
    {
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            knob.SetActive(true);
        }
    }
}
