using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6cutscene : MonoBehaviour
{

    public GameObject bigvirus;
    public GameObject player;
    public GameObject cam;
    public float wait_time;
    private bool triggered;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!triggered)
            {
                StartCoroutine(camshake());
                triggered = true;
            }

        }
    }

    IEnumerator camshake()
    {
        bigvirus.GetComponent<giantvirus>().speed = 0f; //4f
        player.GetComponent<player_control>().stopmove();
        FindObjectOfType<SFX>().Play("virus2_bulletdestroy");
        cam.GetComponentInChildren<Animator>().SetTrigger("shake");
        yield return new WaitForSeconds(2f);
        FindObjectOfType<SFX>().Play("virus2_bulletdestroy");
        cam.GetComponentInChildren<Animator>().SetTrigger("shake");
        yield return new WaitForSeconds(2f);
        cam.GetComponent<camerafollow>().target = bigvirus.transform;
        cam.GetComponentInChildren<Camera>().orthographicSize = 15f;
        yield return new WaitForSeconds(wait_time);
        bigvirus.GetComponent<giantvirus>().speed = 4f;
        player.GetComponent<player_control>().startmove();
        cam.GetComponent<camerafollow>().target = player.transform;
        cam.GetComponentInChildren<Camera>().orthographicSize = 5.597982f;
    }
}
