using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerEye : MonoBehaviour
{
    Vector2 eye_start_position;
    Vector2 mouseposition;
    public float maxrange;
    public bool arrive;
    public float blinktime;
    private float timebtwblink;
    private void Start()
    {
        eye_start_position = transform.position;
    }

    private void Update()
    {
        if (arrive)
        {
            if (timebtwblink <= 0)
            {
                GetComponent<Animator>().SetTrigger("blink");
                timebtwblink = blinktime;
            }
            else
            {
                timebtwblink -= Time.deltaTime;
                mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (mouseposition - eye_start_position).normalized;
                transform.position = eye_start_position + (direction * maxrange);
            }
        }

    }

    public void blinksound()
    {
        FindObjectOfType<SFX>().Play("blink");
    }
}
