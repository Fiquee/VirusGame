using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform Bulletpos;
    public void shoot()
    {
        Instantiate(Bullet, Bulletpos.position, Bulletpos.rotation);
    }
}
