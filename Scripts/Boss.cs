using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    Rigidbody2D rb;
    private bool facingright;
    private float movedir;
    public float jumpforce;
    public float speed;

    int boss_state; //1 = move and jump ; 2 = fly and shoot ; 3 = spawn ; 4 = shoot circular ; 5 = die
    private Transform player;
    private bool startbossfight;
    private float time_to_changestate;
    public float changetime;
    private bool isGrounded;
    private bool prevGrounded;
    public Transform feetpos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Animator bossanim;
    private bool isFlying;
    public GameObject[] spawner;
    public GameObject cam;

    [Header("Attack Settings")]
    public int numberofBullet;
    public int[] c_numberofBullet;
    public float bulletspeed;
    public GameObject bullet;
    private Vector3 startpoint;
    private const float radius = 1f;
    private float timebtwjump;
    public float jumptime;
    private float timebtwattack;
    public float attacktime;
    public float c_attacktime;
    private float c_attacktimecounter;
    public GameObject spiral;
    public Transform spiralpos;
    public GameObject explode_impact;
    public bool die;
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        bossanim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        facingright = false;
        rb = GetComponent<Rigidbody2D>();
        movedir = -1;
        timebtwjump = jumptime;
        timebtwattack = attacktime;
        time_to_changestate = changetime;
        c_attacktimecounter = c_attacktime;
    }

    // Update is called once per frame
    void Update()
    {
        if (startbossfight)
        {
            startpoint = transform.position;
            isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround);
            bossanim.SetBool("isGrounded", isGrounded);
            if (isGrounded && !prevGrounded)
            {
                GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
                FindObjectOfType<SFX>().Play("boss_stomp");
                cam.GetComponent<Animator>().SetTrigger("shake");
            }
            prevGrounded = isGrounded;
            if (isGrounded && boss_state == 1)
            {
                rb.velocity = new Vector2(0 * speed, rb.velocity.y);
                if ((transform.position.x < player.position.x) && !facingright)
                {
                    flip();
                }
                if ((transform.position.x > player.position.x) && facingright)
                {
                    flip();
                }
            }
            else if (die)
            {
                rb.velocity = new Vector2(0 * speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(movedir * speed, rb.velocity.y);
            }
            time_to_changestate -= Time.deltaTime;
            if (time_to_changestate <= 0 && (isGrounded == true || isFlying == true))
            {
                changestate();
                time_to_changestate = changetime;
            }
            switch (boss_state)
            {
                case 1:
                    if (timebtwjump <= 0)
                    {
                        jump();
                        timebtwjump = jumptime;
                    }
                    else
                    {
                        timebtwjump -= Time.deltaTime;
                    }
                    break;
                case 2:
                    if (!isFlying)
                    {
                        isFlying = true;
                        bossanim.SetBool("fly", isFlying);
                        bossanim.SetTrigger("jump");
                        rb.velocity = Vector2.up * jumpforce;
                    }
                    flying();
                    if (timebtwattack <= 0)
                    {
                        rb.velocity = new Vector2(0 * speed, rb.velocity.y);
                        bossanim.SetTrigger("attack");
                        attack(numberofBullet);
                        timebtwattack = attacktime;
                    }
                    else
                    {
                        timebtwattack -= Time.deltaTime;
                    }
                    break;
                case 3:
                    speed = 0f;
                    if (timebtwattack <= 0)
                    {
                        bossanim.SetTrigger("attack");
                        spawnvirus();
                        timebtwattack = attacktime;
                    }
                    else
                    {
                        timebtwattack -= Time.deltaTime;
                    }
                    break;
                case 4:
                    speed = 0f;
                    if (c_attacktimecounter <= 0)
                    {
                        if (num > 5)
                        {
                            num = 0;
                        }
                        bossanim.SetTrigger("attack");
                        circularattack(c_numberofBullet[num]);
                        c_attacktimecounter = c_attacktime;
                        num++;
                    }
                    else
                    {
                        c_attacktimecounter -= Time.deltaTime;
                    }
                    break;
                case 5:
                    focusonboss();
                    bossanim.SetTrigger("die");
                    break;
                default: break;
            }
        }
    }


    void focusonboss()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        obj.GetComponent<player_control>().stopmove();
        cam.GetComponent<camerafollow>().target = this.transform;
        cam.GetComponent<camerafollow>().offset = new Vector3(0f, 0f, -10f);
    }
    void explode()
    {
        FindObjectOfType<camerafollow>().StartCoroutine("returnToPlayer");
        spawnmotherboard();
        Destroy(gameObject);
        FindObjectOfType<SFX>().Play("boss_explode");
        FindObjectOfType<SFX>().Stop("bossfight");
        Instantiate(explode_impact, transform.position, Quaternion.identity);
    }

    public void spawnmotherboard()
    {
        FindObjectOfType<motherboard>().StartCoroutine("spawn");
    }

    void spawnspiral()
    {
        Instantiate(spiral, spiralpos.position, Quaternion.identity);
    }

    // void destroyspiral()
    // {
    //     spiral.GetComponent<des_efx>().destroyobj();
    // }

    void jump()
    {
        bossanim.SetTrigger("jump");
        rb.velocity = new Vector2(movedir * speed, rb.velocity.y);
        rb.velocity = Vector2.up * jumpforce;
    }

    void flying()
    {
        if ((transform.position.x < player.position.x) && !facingright)
        {
            flip();
        }
        if ((transform.position.x > player.position.x) && facingright)
        {
            flip();
        }
        rb.gravityScale = 0;
        rb.velocity = new Vector2(movedir * speed, rb.velocity.y);
    }
    void spawnvirus()
    {
        for (int i = 0; i < spawner.Length; i++)
        {
            spawner[i].GetComponent<bossSpawnpos>().spawn();
        }
    }

    void circularattack(int _numberofBullet)
    {
        FindObjectOfType<SFX>().Play("boss_c_shoot");
        float angleStep = 360f / _numberofBullet;
        float angle = 0f;

        for (int i = 0; i < _numberofBullet; i++)
        {
            float bulletXposition = startpoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float bulletYposition = startpoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 bulletvector = new Vector3(bulletXposition, bulletYposition, 0f);
            Vector3 bulletmovedirection = (bulletvector - startpoint).normalized * bulletspeed;
            GameObject obj = Instantiate(bullet, startpoint, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletmovedirection.x, bulletmovedirection.y);

            angle += angleStep;
        }
    }
    void attack(int _numberofBullet)
    {
        FindObjectOfType<SFX>().Play("boss_shoot");
        if (movedir > 0)
        {
            float angleStep = 150f / _numberofBullet;
            float angle = 90f;

            for (int i = 0; i < _numberofBullet; i++)
            {
                float bulletXposition = startpoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float bulletYposition = startpoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector3 bulletvector = new Vector3(bulletXposition, bulletYposition, 0f);
                Vector3 bulletmovedirection = (bulletvector - startpoint).normalized * bulletspeed;
                GameObject obj = Instantiate(bullet, startpoint, Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletmovedirection.x, bulletmovedirection.y);

                angle += angleStep;
            }
        }
        else if (movedir < 0)
        {
            float angleStep = 150f / _numberofBullet;
            float angle = 120f;
            for (int i = 0; i < _numberofBullet; i++)
            {
                float bulletXposition = startpoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float bulletYposition = startpoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector3 bulletvector = new Vector3(bulletXposition, bulletYposition, 0f);
                Vector3 bulletmovedirection = (bulletvector - startpoint).normalized * bulletspeed;
                GameObject obj = Instantiate(bullet, startpoint, Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletmovedirection.x, bulletmovedirection.y);

                angle += angleStep;
            }
        }


    }



    void flip()
    {
        facingright = !facingright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        movedir = movedir * -1;
        // transform.Rotate(0f, 180f, 0f);
    }

    public void startfight()
    {
        startbossfight = true;
        boss_state = 1;
    }

    public void changestate()
    {
        boss_state++;
        speed = 2f;
        if (boss_state == 4)
        {
            time_to_changestate = 10f;
        }
        else if (boss_state == 5)
        {
            die = true;
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
