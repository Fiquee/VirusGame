using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;

    private Vector2 lastCheckPointPos;
    private Vector2 bigVirusPos;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setposition(Vector2 pos)
    {
        lastCheckPointPos = pos;
    }

    public Vector2 getposition()
    {
        return lastCheckPointPos;
    }

    public void setbigvirusposition(float x, float y)
    {
        bigVirusPos.x = x;
        bigVirusPos.y = y;
    }

    public Vector2 getbigvirusposition()
    {
        Vector2 newpos = new Vector2(bigVirusPos.x, bigVirusPos.y);
        return newpos;
    }
}
