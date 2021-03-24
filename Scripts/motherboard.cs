using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motherboard : MonoBehaviour
{
    public GameObject motherboard_prefab;
    public Transform spawnpos;


    public IEnumerator spawn()
    {
        yield return new WaitForSeconds(5f);
        FindObjectOfType<SFX>().Play("sparkle");
        Instantiate(motherboard_prefab, spawnpos.position, Quaternion.identity);
    }
}
