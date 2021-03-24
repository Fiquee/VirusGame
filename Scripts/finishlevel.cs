using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishlevel : MonoBehaviour
{

    public bool locked;
    Animator finishanimcontrol;
    public GameObject scene_manager;

    private void Start()
    {
        finishanimcontrol = GetComponent<Animator>();
        if (locked)
        {
            finishanimcontrol.SetBool("locked", locked);
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!locked)
        {
            GameObject obj = col.gameObject;
            if (obj.tag == "Player")
            {
                Destroy(obj);
                FindObjectOfType<SFX>().Play("player_finishlevel");
                finishanimcontrol.SetTrigger("finish");
            }
        }
    }

    public void unlock()
    {
        locked = false;
        FindObjectOfType<SFX>().Play("player_collect");
        finishanimcontrol.SetBool("locked", locked);
    }

    public void changelevel()
    {
        Destroy(GameObject.FindGameObjectWithTag("GM"));
        scene_manager.GetComponent<SceneTransitions>().nextScene();
    }


}
