using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusbullet : MonoBehaviour
{
    Vector2 target;
    public float speed;
    private Transform player;
    public GameObject particle;
    private GameObject cam;
    void Start()
    {
        FindObjectOfType<SFX>().Play("virus2_shoot");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        // cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            destroyobj();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            GameObject obj = other.gameObject;
            obj.GetComponent<player_control>().die();
            destroyobj();
        }
        if (other.CompareTag("wall") || other.CompareTag("floor") || other.CompareTag("trap") || other.CompareTag("destroyable_floor"))
        {
            destroyobj();
        }
    }

    void destroyobj()
    {
        FindObjectOfType<SFX>().Play("virus2_bulletdestroy");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.GetComponent<Animator>().SetTrigger("shake");
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
