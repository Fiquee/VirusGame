using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_control : MonoBehaviour
{

    //movement things
    private Animator animcontrol;
    public Transform trans;
    public Rigidbody2D rb;
    public Transform feetpos;
    public LayerMask whatIsGround;
    private BoxCollider2D hitbox;
    private float moveinput;
    public float speed;
    public bool facingright = true;
    public GameObject jumpparticles;
    public GameObject righteffect;
    public GameObject lefteffect;

    // Jumping things

    public float checkRadius;

    public float jumpTime;
    private float jumpTimeCounter;
    private bool jump;

    public float jumpforce;


    public bool isdead;
    public bool canmove;
    public float dieforce;
    // public float jumpInitialTimer;
    // private float jumpcounter;

    private bool isGrounded;
    public bool level0;
    public bool credit;
    public bool isPaused;
    private GameMaster gm;



    void Start()
    {
        isdead = false;
        animcontrol = GetComponent<Animator>();
        animcontrol.SetBool("isRunning", false);
        hitbox = GetComponent<BoxCollider2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        if (gm.getposition().x != 0 && gm.getposition().y != 0)
        {
            transform.position = gm.getposition();
        }
        moveinput = 1;
        // jumpcounter = jumpInitialTimer;
    }

    void Update()
    {
        if (!isPaused)
        {
            if (level0 || credit)
            {
                if (!isdead && canmove)
                {
                    rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
                }
            }
            else if (!isdead && canmove)
            {

                // jumpcounter -= Time.deltaTime;
                isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround);
                animcontrol.SetBool("isGrounded", isGrounded);
                // moveinput = Input.GetAxisRaw("Horizontal");
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    FindObjectOfType<SFX>().Play("player_changedir");
                    changedir();
                    if (moveinput > 0 && !facingright)
                    {
                        spawnlefteffect();
                        flip();
                    }

                    if (moveinput < 0 && facingright)
                    {
                        spawnrighteffect();
                        flip();
                    }
                }

                rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);

                if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
                {
                    FindObjectOfType<SFX>().Play("player_jump");
                    animcontrol.SetTrigger("jump");
                    Instantiate(jumpparticles, feetpos.position, Quaternion.identity);
                    rb.velocity = Vector2.up * jumpforce;
                }

                // if (Input.GetKey(KeyCode.Space) && isjumping == true)
                // {
                //     if (jumpTimeCounter > 0)
                //     {
                //         rb.velocity = Vector2.up * jumpforce;
                //         jumpTimeCounter -= Time.deltaTime;
                //     }
                //     else
                //     {
                //         jumpTimeCounter = jumpTime;
                //         isjumping = false;
                //     }
                // }

                // if (Input.GetKeyUp(KeyCode.Space))
                // {
                //     jumpTimeCounter = jumpTime;
                //     isjumping = false;
                // }


                // if (Input.GetKeyDown(KeyCode.Space))
                // {
                //     GetComponent<Shooting>().shoot();
                // }



                // anim.SetFloat("speed", moveinput * moveinput);

                // if (jumpcounter == 0 || jumpcounter < 0)
                // {
                //      isjumping = true;
                //      jumpTimeCounter = jumpTime;
                //     rb.velocity = Vector2.up * jumpforce;
                //     jumpcounter = jumpInitialTimer;
                // }
            }
        }
    }



    public void stopmove()
    {
        moveinput = 0;
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
        animcontrol.SetBool("isRunning", false);
        canmove = false;
    }

    public void startmove()
    {
        if (facingright)
        {
            moveinput = 1;
        }
        else
        {
            moveinput = -1;
        }
        animcontrol.SetBool("isRunning", true);
        canmove = true;
    }

    void spawnlefteffect()
    {
        Instantiate(lefteffect, feetpos.position, Quaternion.identity);
    }

    void spawnrighteffect()
    {
        Instantiate(righteffect, feetpos.position, Quaternion.identity);
    }

    void changedir()
    {
        moveinput = moveinput * -1;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "wall")
        {
            FindObjectOfType<SFX>().Play("player_changedir");
            changedir();
            if (moveinput > 0 && !facingright)
            {
                spawnlefteffect();
                flip();
            }

            if (moveinput < 0 && facingright)
            {
                spawnrighteffect();
                flip();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("trap"))
        {
            die();
        }
    }
    void flip()
    {
        facingright = !facingright;
        // Vector3 theScale = trans.localScale;
        // theScale.x *= -1;
        // transform.localScale = theScale;
        transform.Rotate(0f, 180f, 0f);
    }
    public void die()
    {
        isdead = true;
        hitbox.enabled = false;
        FindObjectOfType<SFX>().Play("player_die");
        rb.velocity = new Vector2(-0.4f * dieforce, 3f * dieforce);
        animcontrol.SetTrigger("die");
        StartCoroutine("destroyobj");
    }

    IEnumerator destroyobj()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
        Scene scene = SceneManager.GetActiveScene();
        Destroy(SFX.instance.gameObject); //if die, destroy the current instance of SFX and after respawn it will use the new instance
        SceneManager.LoadScene(scene.name);
    }

    public Animator GetAnimator()
    {
        return animcontrol;
    }

    public float getmoveinput()
    {
        return moveinput;
    }

    public void footstep()
    {
        if (isGrounded)
        {
            FindObjectOfType<SFX>().Play("footstep");
        }
    }
}
