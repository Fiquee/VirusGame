using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{

    public bool islevel;
    public static BGMmanager bgm_instance;
    // Start is called before the first frame update

    void Awake()
    {
        if (bgm_instance == null)
        {
            bgm_instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

    }

    public void PlayBossFightBGM()
    {
        FindObjectOfType<SFX>().Play("bossfight");
    }
}
