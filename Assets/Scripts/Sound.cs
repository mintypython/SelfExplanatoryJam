using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string _name;

    public AudioClip _clip;

    public bool _loop;

    [Range(0f,1f)]
    public float _volume;

    [Range(0.1f,3f)]
    public float _pitch;

    [HideInInspector]
    public AudioSource _source;
}
