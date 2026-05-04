using UnityEngine.Audio;
using System;
using UnityEngine;
public class AudioManager : MonoBehaviour //Lookup how to do audio properly
{

    public Sound[] _sounds;

    public float _maxVolume = 1f;

    public static AudioManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        if(instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        GetSound();
    }

    private void GetSound()
    {
        foreach (Sound s in _sounds)
        {
            s._source = gameObject.AddComponent<AudioSource>();
            s._source.clip = s._clip;

            s._source.volume = s._volume;
            s._source.pitch = s._pitch;
            s._source.loop = s._loop;
        }

    }

    void Start()
    {
        FindAnyObjectByType<AudioManager>().Play("MainMenuTheme"); //MainMenu Music
    }
    public void Play(string name)
    {
        //GetSound();
        Sound s = Array.Find(_sounds, sound => sound._name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " Is not found");
            return;
        }
        s._source.volume = s._volume;
        s._source.pitch = s._pitch;
        s._source.Play();


    }

    public void LowerVolume(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound._name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " Is not found");
            return;
        }
        s._source.volume -= 0.01f;

    }
    public void RaiseVolume(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound._name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " Is not found");
            return;
        }
        if (s._source.volume <= _maxVolume)
        {
            s._source.volume += 0.01f;
        }
    }

    public void MuteVolume(string name)
    {
        Debug.Log("hello");
        Sound s = Array.Find(_sounds, sound => sound._name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " Is not found");
            return;
        }
        s._volume = 0f;
    }

    public void UnMuteVolume(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound._name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " Is not found");
            return;
        }
        s._volume = _maxVolume;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound._name == name);
        if (s==null)
        {
            Debug.LogWarning("Sound: " + name + " Is not found");
            return;
        }
        s._source.Stop();
    }
}
