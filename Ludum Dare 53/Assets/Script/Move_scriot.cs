using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_scriot : MonoBehaviour
{

    [SerializeField] float speed;
    private float distance;
   
    void Update()
    {
        distance = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * distance * Time.deltaTime);
    }
}
