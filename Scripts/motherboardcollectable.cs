using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class motherboardcollectable : MonoBehaviour
{
    private float sfxtime;
    public float start_sfxtime;
    private GameObject scene_manager;
    private void Start()
    {
        scene_manager = GameObject.FindGameObjectWithTag("scenemanager");
    }

    void Update()
    {
        if (sfxtime <= 0)
        {
            //play sfx
            sfxtime = start_sfxtime;
        }
        else
        {
            sfxtime -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<SFX>().Play("player_collect");
            FindObjectOfType<SFX>().Stop("sparkle");
            Destroy(other.gameObject);
            Destroy(gameObject);
            scene_manager.GetComponent<SceneTransitions>().creditscene();
        }
    }
}
