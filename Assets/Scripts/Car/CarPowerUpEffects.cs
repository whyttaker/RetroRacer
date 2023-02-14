using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPowerUpEffects : MonoBehaviour
{
    [Tooltip("The movement script that will be adjusted by the different power ups.")]
    public CarMovement m_PlayerMovement;

    private float m_PowUpDur;
    private float m_PowUpVal;
    private float m_TimePassed;

    private bool m_IsSpeedUp = false;
    private float m_baseSpeed;


    public void Awake()
    {
        m_PlayerMovement = GetComponent<CarMovement>();
        m_baseSpeed = m_PlayerMovement.m_Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            IPowerUp PowerUp = other.GetComponent<IPowerUp>(); //get whatever powerup script the thing it collided with has

            //get the duration and value associated with the power up
            m_PowUpDur = PowerUp.GetDuration();
            m_PowUpVal = PowerUp.GetValue();

            if (PowerUp is SpeedUp) // toggle speed up effects on
            {
                m_IsSpeedUp = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //countdown for timer
        if (m_PowUpDur > 0f)
        {
            m_PowUpDur -= Time.deltaTime;
            if (m_IsSpeedUp)
            {
                float newSpeed = m_baseSpeed * m_PowUpVal;
                m_PlayerMovement.m_Speed = newSpeed;
            }
        }
        else
        {
            if (m_IsSpeedUp)
            {
                m_PlayerMovement.m_Speed = m_baseSpeed;
                m_IsSpeedUp = false;
            }
        }
    }
}
