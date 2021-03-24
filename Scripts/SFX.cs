using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class SFX : MonoBehaviour
{
    public bool islevel;
    public bool mainmenu;
    public Sound[] sfx;
    public static SFX instance;


    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sfx)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.sb;
        }
    }
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (islevel && checkIsPlaying("theme")) //to stop theme music after get into the game
        {
            Stop("theme");
        }
        if (islevel && !checkIsPlaying("levels")) //to play level music if the music is not playing in the level
        {
            Play("levels");
        }
        if (!islevel)
        {
            if (checkIsPlaying("levels"))  //to stop level music when we are in the non-level
            {
                Stop("levels");
            }
        }
        if (mainmenu && !checkIsPlaying("theme"))
        {
            Play("theme");
        }
    }

    public bool checkIsPlaying(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return false;
        }
        return s.source.isPlaying;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return;
        }
        s.source.Stop();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name); //find object in array by name
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return;
        }
        s.source.Pause();
    }

    public void unPause(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return;
        }
        s.source.UnPause();
    }

    public void setVolume(string name, float vol)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return;
        }
        s.volume = vol;
        s.source.volume = s.volume;
    }
    public void PlayBossFightBGM()
    {
        FindObjectOfType<SFX>().Play("bossfight");
    }
}
