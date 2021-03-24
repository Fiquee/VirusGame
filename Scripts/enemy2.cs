using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    private Animator virusanim;
    public bool canshoot;
    private float timebtwshoot;
    public float shoottime;
    private Transform virus2;
    public GameObject bullet;
    void Start()
    {
        virusanim = GetComponent<Animator>();
        virus2 = GetComponent<Transform>();
        timebtwshoot = shoottime;
    }

    // Update is called once per frame
    void Update()
    {
        if (canshoot)
        {
            if (timebtwshoot <= 0)
            {
                shoot();
                timebtwshoot = shoottime;
            }
            else
            {
                timebtwshoot -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Player")
        {
            if (obj.GetComponent<player_control>().isdead == false)
            {
                obj.GetComponent<player_control>().die();
            }
        }
    }

    void shoot()
    {
        virusanim.SetTrigger("attack");
        Instantiate(bullet, virus2.position, Quaternion.identity);
    }
}
