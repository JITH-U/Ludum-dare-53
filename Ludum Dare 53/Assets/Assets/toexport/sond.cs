
using UnityEngine;
[System.Serializable]
public class sond
{
    public string Name;
    public AudioClip audioClip;
    [Range(0,1)]
    public float volume;
    [Range(0.2f,3)]
    public float pitch;
    [HideInInspector] 
    public AudioSource source;
    public bool loop;
}
