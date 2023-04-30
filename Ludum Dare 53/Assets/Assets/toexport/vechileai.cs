using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vechileai : MonoBehaviour
{
    public int speed, targetno;
    public GameObject[] waypoint;
    public Rigidbody rb;
    private Transform targetpos;
    private bool loopback;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        targetpos = waypoint[targetno].transform;
        transform.position = Vector3.MoveTowards(transform.position, targetpos.position, speed *Time.deltaTime);
        transform.LookAt(targetpos);
        float distance = Vector3.Distance(transform.position, targetpos.position);
        if(distance < 0.05)
        {
            //if(targetno < waypoint.Length-1) {
            //    targetno++;
                
            //}
            //else
            //{
            //    targetno = 0;
            //}
            if(!loopback)
            {
                if (targetno < waypoint.Length - 1)
                {
                    targetno++;

                }
                else
                {
                    loopback = true;
                }
            }
            else if (loopback)
            {
                if(targetno > 0)
                {
                    targetno--;
                }
                else
                {
                    loopback = false;
                }
            }
          
            
        }
        
    }
   
}
