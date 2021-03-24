using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_indicator : MonoBehaviour
{
    public int level_index = 0;
    public static level_indicator instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (level_index > 10)
        {
            level_index = 0;
        }

    }
}
