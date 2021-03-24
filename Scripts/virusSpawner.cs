using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusSpawner : MonoBehaviour
{
    public float spawntime;
    public GameObject virus;
    private Transform spawnpos;

    private void Start()
    {
        spawnpos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startspawning()
    {
        StartCoroutine("waitforspawn");
    }

    IEnumerator waitforspawn()
    {
        yield return new WaitForSeconds(spawntime);
        FindObjectOfType<SFX>().Play("virus1_spawn");
        Instantiate(virus, spawnpos.position, Quaternion.identity);
    }
}
