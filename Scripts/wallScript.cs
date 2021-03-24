using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour
{
    public GameObject cutsceneTrigger;
    public GameObject BGM_manager;

    private void Start()
    {
        SFX.instance.islevel = false;
    }
    void getstarted()
    {
        cutsceneTrigger.GetComponent<cutscenetrigger>().startbossFight();
    }

    void startBGM()
    {
        BGM_manager.GetComponent<SFX>().PlayBossFightBGM();
    }
}
