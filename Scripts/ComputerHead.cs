using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerHead : MonoBehaviour
{
    public void isArrived()
    {
        GameObject eye = GameObject.FindGameObjectWithTag("computereye");
        eye.GetComponent<Animator>().SetBool("arrive", true);
        eye.GetComponent<Animator>().SetTrigger("blink");
        eye.GetComponent<ComputerEye>().arrive = true;
    }
}

