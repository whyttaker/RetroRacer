using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPowerUpEffects : MonoBehaviour
{
    [Tooltip("The movement script that will be adjusted by the different power ups.")]
    public CarMovement m_PlayerMovement;

    // car speed related member variables
    public float m_SpeedDur = 0f; // both speeds share a timer so they can override each other smoothly
    public bool m_IsSpeedUp = false;
    public bool m_IsSpeedDown = false;
    public float m_SpeedMult = 1f;
    private float m_BaseSpeed;

    // invert controls related member variables
    public float m_InvertDur = 0f;
    public bool m_IsInverted = false;

    //boost related member variables
    public float m_BoostMultDur = 0f;
    public bool m_IsBoostMult = false;
    public float m_BoostMult = 1f;


    public void Awake()
    {
        m_PlayerMovement = GetComponent<CarMovement>();
        m_BaseSpeed = m_PlayerMovement.m_Speed;
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
                float newSpeed = m_BaseSpeed * m_SpeedMult;
                m_PlayerMovement.m_Speed = newSpeed;
            }
            else if (m_IsSpeedDown)
            {
                // slow down the car
                float newSpeed = m_BaseSpeed / m_SpeedMult;
                m_PlayerMovement.m_Speed = newSpeed;
            }

        }
        else
        {
            // reset to base speed and toggle the power ups off
            m_PlayerMovement.m_Speed = m_BaseSpeed;

            if (m_IsSpeedUp)
            {
                m_IsSpeedUp = false;
            }
            else if (m_IsSpeedDown)
            {
                m_IsSpeedDown = false;
            }
        }

        //countdown for InvertDur timer
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
            m_IsInverted = false;
            m_PlayerMovement.m_Inverted = false;
        }

        //countdown for BoostMultDur timer
        if (m_BoostMultDur > 0f)
        {
            m_BoostMultDur -= Time.deltaTime;
            if(m_IsBoostMult)
            {
                // change boost multiplier in the movement script
                m_PlayerMovement.m_BoostMult = m_BoostMult;
            }
        }
        else
        {
            //change multipliers back to 1f
            m_IsBoostMult = false;
            m_BoostMult = 1f;
            m_PlayerMovement.m_BoostMult = 1f;

        }
    }
}
