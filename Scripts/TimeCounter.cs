using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public float lockedtime;
    float countertime;
    int countertexttime;
    public Text countertext;
    public Image clock;
    private bool unlock;
    void Start()
    {
        countertime = lockedtime;
    }

    // Update is called once per frame
    void Update()
    {
        if (countertime <= 0 && !unlock)
        {
            unlock = true;
            clock.GetComponent<Animator>().SetTrigger("stop");
            GameObject.FindGameObjectWithTag("Finish").GetComponent<finishlevel>().unlock();
        }
        else if (countertime > 0)
        {
            countertexttime = (int)countertime;
            countertext.text = countertexttime.ToString();
            countertime -= Time.deltaTime;
        }
    }
}
