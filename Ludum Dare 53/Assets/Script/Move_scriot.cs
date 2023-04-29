using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_scriot : MonoBehaviour
{

    [SerializeField] float speed;
    private float movement;
   
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * movement * Time.deltaTime);

        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime; 
        transform.Translate(0, 0, translation); 



    }
}
