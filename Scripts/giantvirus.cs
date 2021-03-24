using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giantvirus : MonoBehaviour
{

    private float movedir;
    public float speed;
    public Rigidbody2D rb;
    private Animator anim;
    public Transform player;
    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        if (gm.getbigvirusposition().x != 0 && gm.getbigvirusposition().y != 0)
        {
            transform.position = gm.getbigvirusposition();
        }
        anim = GetComponent<Animator>();
        movedir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && !player.Equals(null))
        {
            if (player.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(movedir * speed, rb.velocity.y);
            }
            else if (player.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(-movedir * speed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(0 * speed, rb.velocity.y);
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
}
