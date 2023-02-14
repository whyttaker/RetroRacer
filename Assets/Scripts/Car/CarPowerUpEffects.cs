using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPowerUpEffects : MonoBehaviour
{
    [Tooltip("The movement script that will be adjusted by the different power ups.")]
    public CarMovement m_PlayerMovement;

    private float m_PowUpDur = 0f;
    private float m_PowUpVal = 0f;

    // car speed related member variables
    private float m_SpeedDur = 0f; // both speeds share a timer so they can override each other smoothly
    private bool m_IsSpeedUp = false;
    private bool m_IsSpeedDown = false;
    private float m_baseSpeed;

    // invert controls related member variables
    private float m_InvertDur = 0f;
    private bool m_IsInverted = false;


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
                m_SpeedDur = m_PowUpDur;
                if(m_IsSpeedDown)
                {
                    m_IsSpeedDown = false; //toggle off previous speed down
                }
            }

            else if (PowerUp is SpeedDown)
            {
                m_IsSpeedDown = true;
                m_SpeedDur = m_PowUpDur;
                if(m_IsSpeedUp)
                {
                    m_IsSpeedUp = false; //toggle off previous speed up
                }
            }

            else if (PowerUp is InvertControls)
            {
                m_IsInverted = true;
                m_InvertDur = m_PowUpDur;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //countdown for SpeedDur timer
        if (m_SpeedDur > 0f)
        {
            m_SpeedDur -= Time.deltaTime;
            if (m_IsSpeedUp)
            {
                // speed up the car
                float newSpeed = m_baseSpeed * m_PowUpVal;
                m_PlayerMovement.m_Speed = newSpeed;
            }
            else if (m_IsSpeedDown)
            {
                // slow down the car
                float newSpeed = m_baseSpeed / m_PowUpVal;
                m_PlayerMovement.m_Speed = newSpeed;
                Debug.Log(newSpeed);
            }

        }
        else
        {
            // reset to base speed and toggle the power ups off
            m_PlayerMovement.m_Speed = m_baseSpeed;

            if (m_IsSpeedUp)
            {
                m_IsSpeedUp = false;
            }
            else if (m_IsSpeedDown)
            {
                m_IsSpeedDown = false;
            }
        }
        
        if (m_InvertDur > 0f)
        {
            m_InvertDur -= Time.deltaTime;
            if (m_IsInverted)
            {
                // invert car controls
                m_PlayerMovement.m_Inverted = true;
            }
        }
        else
        {
            // toggle inverted controls back off
            if (m_IsInverted)
            {
                m_PlayerMovement.m_Inverted = false;
            }
        }
    }
}
