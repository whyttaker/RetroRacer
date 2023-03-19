using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorvetteStats : CarMovement
{
    private Vector3 MoveForce;
    public float steerAngle = 10;
    public float Drag = 0.98f;
    private float realAcceleration = 180f;
    private float traction = 0.5f;


    public CorvetteStats()
    {
        m_Speed = 180;
        m_Handling = 50;
        m_Accel = 50;
    }

    new public void FixedUpdate()
    {
        if (Input.GetButton("Fire1" + m_PlayerNumber) && Input.GetButton("Horizontal" + m_PlayerNumber))
        {
            m_isDrifting = true;
        }
        else
            m_isDrifting = false;


        MoveForce += transform.forward * realAcceleration * Input.GetAxis("Vertical" + m_PlayerNumber) * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        float invertMult = 1f;
        if (m_Inverted) // invert turn controls if player picked up invert controls power up
        {
            invertMult = -1f;
        }

        float steerInput = Input.GetAxis("Horizontal" + m_PlayerNumber);
        transform.Rotate(invertMult*(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime) / 32);

        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, m_Speed);

        if (m_isDrifting)
        {
            MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, traction * Time.deltaTime) * MoveForce.magnitude;
        }
        else
        {
            MoveForce = transform.forward * MoveForce.magnitude;
        }
        m_Rigidbody.AddForce(Vector3.down * 9.81f * 10, ForceMode.Acceleration);
    }



}
