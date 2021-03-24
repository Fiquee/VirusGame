using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingelevator : MonoBehaviour
{
    public Transform target;
    public Transform start;
    public float speed;
    private Vector2 targetpos;
    private Vector2 startpos;
    private Vector2 destination;
    public float waitingtime;
    // Start is called before the first frame update
    void Start()
    {
        targetpos = new Vector2(target.position.x, target.position.y);
        startpos = new Vector2(start.position.x, start.position.y);
        destination = targetpos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        if (transform.position == target.position)
        {
            StartCoroutine("waittogostart");
        }
        if (transform.position == start.position)
        {
            StartCoroutine("waittogotarget");
        }
    }

    private void movetotarget()
    {
        destination = targetpos;
    }

    private void movetostart()
    {
        destination = startpos;
    }

    IEnumerator waittogostart()
    {
        yield return new WaitForSeconds(1.5f);
        movetostart();
    }

    IEnumerator waittogotarget()
    {
        yield return new WaitForSeconds(waitingtime);
        movetotarget();
    }
}
