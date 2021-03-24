using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSmallvirus : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    float movedir;
    public float lifetime;
    private float lifetimecounter;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            movedir = -1;
        }
        else if (rand == 1)
        {
            movedir = 1;
        }
        lifetimecounter = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(movedir * speed, rb.velocity.y);
        if (lifetimecounter <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifetimecounter -= Time.deltaTime;
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
        if (obj.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
