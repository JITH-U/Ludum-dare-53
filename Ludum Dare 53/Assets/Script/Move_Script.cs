using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Script : MonoBehaviour
{

    public float speed = 10.0f;
    private float direction = 0.0f;
   

    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
       
    }

}
