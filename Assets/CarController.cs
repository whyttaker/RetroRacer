using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private Vector3 MoveForce;
    public float m_Accel = 50;
    public float Drag = 0.98f;
    public float m_Speed = 35;
    public float steerAngle = 20;
    public float m_Handling = 2;
    public float m_Boost;
    public float m_BoostMult;
    public bool m_Inverted;

    // Update is called once per frame
    void Update()
    {
        MoveForce += transform.forward * m_Accel * Input.GetAxis("Vertical");
        transform.position += MoveForce * Time.deltaTime;

        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime);

        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, m_Speed);

        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, m_Handling * Time.deltaTime) * MoveForce.magnitude;
    }
}
