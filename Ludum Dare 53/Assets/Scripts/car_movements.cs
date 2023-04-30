using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_movements : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody controller_RB,carcolrb;
    private float _verticalinput, _horizontalinput;
    public float frwdspeed, revspeed, turnangle , gravity = 10f , wheelrot;
    public Transform centrepos, lftwheel, rhtwheel;
    public TrailRenderer[] tyremrks;
    public LayerMask ground;

    private bool _isGrounded,tyremark;
    void Start()
    {
        controller_RB.transform.parent = null;
        carcolrb.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        chkdrift();
        transform.position = controller_RB.transform.position;

        _verticalinput = Input.GetAxis("Vertical");
        _horizontalinput = Input.GetAxis("Horizontal");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, _horizontalinput * turnangle * Input.GetAxis("Vertical"), 0) * Time.deltaTime);
        lftwheel.localRotation= Quaternion.Euler(lftwheel.transform.rotation.x, _horizontalinput * wheelrot, lftwheel.transform.rotation.z);
        rhtwheel.localRotation = Quaternion.Euler(rhtwheel.transform.rotation.x, _horizontalinput * wheelrot, rhtwheel.transform.rotation.z);
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        _isGrounded = false;
        if (Physics.Raycast(centrepos.position, -transform.up, out hit, 0.5f, ground))
        {
            _isGrounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        if (_isGrounded)
        {
            controller_RB.drag = 4;
            if (Mathf.Abs(_verticalinput) > 0)
            {
                controller_RB.AddForce(transform.forward * _verticalinput * 250f * frwdspeed, ForceMode.Acceleration);
            }
            else
            {
                controller_RB.AddForce(transform.forward * _verticalinput * 250f * revspeed, ForceMode.Acceleration);
            }
        }
        else
        {
            controller_RB.drag = 0.1f;
            controller_RB.AddForce(Vector3.up * -gravity * 50f);
        }
        carcolrb.MoveRotation(transform.rotation);
    }
    void chkdrift()
    {
        if(controller_RB.velocity.x != 0 && _horizontalinput!= 0)
        {
            startdrift();
        }
        else
        {
            stopdrift();
        }
    }
    void startdrift()
    {
        if (tyremark)
        {
            return;
        }
        foreach(TrailRenderer t in tyremrks)
        {
            t.emitting = true;
        }
        tyremark = true;
    }
    void stopdrift()
    {
        if (!tyremark)
        {
            return;
        }
      
        foreach (TrailRenderer t in tyremrks)
        {
            t.emitting = false;
        }
        tyremark = false;
    }
}
