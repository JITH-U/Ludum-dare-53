using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform car;
    public float distance = 6.4f;
    public float height = 1.8f;
    public float rotationDamping = 3.0f;
    public float heightDamping = 2.0f;
    public float zoomRatio = 0.5f;
    public float defaultFOV = 60f;
    bool carSelected;
    private Vector3 rotationVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Camera_Update();
    }
    private void Camera_Update()
    {

       
        float wantedAngle = rotationVector.y;
        float wantedHeight = car.position.y + height;
        float myAngle = transform.eulerAngles.y;
        float myHeight = transform.position.y;

        myAngle = Mathf.LerpAngle(myAngle, wantedAngle, rotationDamping * Time.deltaTime);
        myHeight = Mathf.Lerp(myHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);
        transform.position = car.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        Vector3 temp = transform.position;
        temp.y = myHeight;
        transform.position = temp;
        if (carSelected)
        {
            transform.LookAt(car);
        }

    }

    void FixedUpdate()
    {
        SettingView();
    }

    private void SettingView()
    {
        if (carSelected)
        {
            Vector3 localVelocity = car.InverseTransformDirection(car.GetComponent<Rigidbody>().velocity);
            if (localVelocity.z < -0.1f)
            {
                Vector3 temp = rotationVector;
                temp.y = car.eulerAngles.y + 180;
                rotationVector = temp;
            }
            else
            {
                Vector3 temp = rotationVector;
                temp.y = car.eulerAngles.y;
                rotationVector = temp;
            }
            float acc = car.GetComponent<Rigidbody>().velocity.magnitude;
            GetComponent<Camera>().fieldOfView = defaultFOV + acc * zoomRatio * Time.deltaTime;
        }

    }
}

