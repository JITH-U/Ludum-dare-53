using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_scriot : MonoBehaviour
{
 
    void Update()
    {
        
       var horizontal = Input.GetAxis("Horizontal")*Time.deltaTime*5;
       var vertical = Input.GetAxis("Vertical")*Time.deltaTime*5;
        transform.Translate(horizontal,0,vertical);

    }
}
