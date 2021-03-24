using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public BoxCollider2D col;
    public float speed;
    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject border = col.gameObject;
        if (col.tag == "bulletdestroyer" || col.tag == "wall")
        {
            Destroy(gameObject);

        }
    }
}
