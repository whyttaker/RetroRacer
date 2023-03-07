using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyotaStats : CarMovement
{
    private Vector3 MoveForce;
    public float steerAngle = 10;
    public float Drag = 0.98f;
    private float realAcceleration = 18f;
    private float traction = 0.5f;

    public ToyotaStats()
    {
        m_Speed = 4;
        m_Handling = 1;
        m_Accel = 1;
    }

    public void FixedUpdate(){
        if(Input.GetButton("Fire1")){
            m_isDrifting = true;
        }
        else
            m_isDrifting = false;
        

        if(!(m_isDrifting)){
            MoveForce += transform.forward * realAcceleration * Input.GetAxis("Vertical");
            transform.position += MoveForce * Time.deltaTime;
        }

        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate((Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime)/32);

        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, 130);

        if(m_isDrifting)
            MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, traction * Time.deltaTime) * MoveForce.magnitude;
    }

}
