using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawnpos : MonoBehaviour
{
    public GameObject virus;
    public void spawn()
    {
        FindObjectOfType<SFX>().Play("virus1_spawn");
        Instantiate(virus, transform.position, Quaternion.identity);
    }
}
