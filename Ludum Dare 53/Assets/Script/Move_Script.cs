using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Script : MonoBehaviour
{

    [SerializeField] float speed ;
    private float direction ;
   

    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
       
    }

}
