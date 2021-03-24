using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Transform start;
    public float speed;
    private Vector2 targetpos;
    private Vector2 startpos;
    private Vector2 destination;
    private Animator elevanim;
    public bool goback; //for certain elevator to make it go back just after reach destination
    void Start()
    {
        elevanim = GetComponent<Animator>();
        targetpos = new Vector2(target.position.x, target.position.y);
        startpos = new Vector2(start.position.x, start.position.y);
        destination = startpos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        if (goback)
        {
            if (transform.position == target.position)
            {
                movetostart();
            }
        }
        if (transform.position == start.position)
        {
            FindObjectOfType<SFX>().Stop("elevator");
            elevanim.SetBool("moving", false);
        }
        else
        {
            FindObjectOfType<SFX>().Play("elevator");
            elevanim.SetBool("moving", true);
        }
    }

    public void movetotarget()
    {
        destination = targetpos;
    }

    public void movetostart()
    {
        destination = startpos;
    }
}
