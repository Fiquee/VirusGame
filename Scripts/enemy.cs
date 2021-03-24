using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float speed;
    public float movedir;
    public Rigidbody2D rb;
    public Animator enemyanim;
    float tempdir;

    void Start()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            movedir = -1;
        }
        else if (rand == 1)
        {
            movedir = 1;
        }


        enemyanim.SetBool("walking", true);
    }

    void Update()
    {
        rb.velocity = new Vector2(movedir * speed, rb.velocity.y);
    }

    public void waitandchangedir()
    {
        tempdir = movedir;
        movedir = 0;
        enemyanim.SetBool("walking", false);
        StartCoroutine("wait");
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        movedir = tempdir * -1;
        enemyanim.SetBool("walking", true);
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
        if (obj.tag == "enemy")
        {
            movedir = movedir * -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("trap"))
        {
            Destroy(gameObject);
        }
    }
}
