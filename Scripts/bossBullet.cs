using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{

    public GameObject particles;
    private bool bossisDead;

    private void Update()
    {
        bossisDead = GameObject.FindObjectOfType<Boss>().die;
        if (bossisDead)
        {
            destroybullet();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("wall") || other.CompareTag("floor") || other.CompareTag("trap"))
        {
            destroybullet();
        }
        if (other.CompareTag("Player"))
        {
            destroybullet();
            GameObject obj = other.gameObject;
            if (obj.GetComponent<player_control>().isdead == false)
            {
                obj.GetComponent<player_control>().die();
            }
        }
    }

    public void destroybullet()
    {
        FindObjectOfType<SFX>().Play("boss_bulletdestroy");
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
