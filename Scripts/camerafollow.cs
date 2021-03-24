using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Vector3 offset;
    public bool islevel;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SFX.instance.islevel = islevel;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        else
        {
            transform.position = transform.position;
        }
    }

    IEnumerator returnToPlayer()
    {
        yield return new WaitForSeconds(2.5f);
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        offset = new Vector3(7f, 10f, -10f);
        yield return new WaitForSeconds(0.5f);
        obj.GetComponent<player_control>().startmove();
    }
}
