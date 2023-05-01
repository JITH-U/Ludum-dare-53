using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carsound : MonoBehaviour
{
    public float minspeed, maxspeed ,minpitch,maxpitch;
    public Rigidbody carrb;
    public AudioSource carsnd;
    private float pitchfromcar,currentspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enginesound();
    }
    private void enginesound()
    {
        currentspeed = carrb.velocity.magnitude;
        pitchfromcar = carrb.velocity.magnitude / 50f;
        if(currentspeed < minspeed)
        {
            carsnd.pitch = minpitch;
        }
        if(currentspeed > minspeed && currentspeed < maxspeed)
        {
            carsnd.pitch = minpitch + pitchfromcar;
        }
        if (currentspeed > maxspeed)
        {
            carsnd.pitch = maxpitch;
        }
    }
}
