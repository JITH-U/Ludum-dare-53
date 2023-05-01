using System;

using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public sond[] sound;


    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
        foreach(sond s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
        }
      
    }

    public void play(string name)
    {
        sond s = Array.Find(sound, sound => sound.Name == name);
        
        if (s == null)
        {
            Debug.Log("Sound not found");
            return;
        }
        s.source.Play();

    }
}
