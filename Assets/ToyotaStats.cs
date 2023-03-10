using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyotaStats : CarMovement
{
    private Vector3 MoveForce;
    public float steerAngle = 10;
    public float Drag = 0.98f;
    private float realAcceleration = 180f;
    private float traction = 0.5f;

    public ToyotaStats()
    {
        m_Speed = 4;
        m_Handling = 1;
        m_Accel = 1;
    }

    public void FixedUpdate(){
        if(Input.GetButton("Fire1") && Input.GetButton("Horizontal")){
            m_isDrifting = true;
        }
        else
            m_isDrifting = false;
        

            MoveForce += transform.forward * realAcceleration * Input.GetAxis("Vertical")* Time.deltaTime;
            transform.position += MoveForce * Time.deltaTime;

        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate((Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime)/32);

        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, 130);

        if (m_isDrifting) {
            MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, traction * Time.deltaTime) * MoveForce.magnitude;
        } else {
            MoveForce = transform.forward * MoveForce.magnitude;
        }
        m_Rigidbody.AddForce(Vector3.down * 9.81f * 10, ForceMode.Acceleration);
    }


}
