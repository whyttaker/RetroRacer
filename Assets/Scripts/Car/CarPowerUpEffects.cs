using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPowerUpEffects : MonoBehaviour
{
    [Tooltip("The movement script that will be adjusted by the different power ups.")]
    public CarMovement m_PlayerMovement;

    // car speed related member variables
    private float m_SpeedDur = 0f; // both speeds share a timer so they can override each other smoothly
    private bool m_IsSpeedUp = false;
    private bool m_IsSpeedDown = false;
    private float m_SpeedMult = 1f;
    private float m_BaseSpeed;

    // invert controls related member variables
    private float m_InvertDur = 0f;
    private bool m_IsInverted = false;

    //boost related member variables
    private float m_BoostMultDur = 0f;
    private bool m_IsBoostMult = false;
    private float m_BoostMult = 1f;


    public void Awake()
    {
        m_PlayerMovement = GetComponent<CarMovement>();
        m_BaseSpeed = m_PlayerMovement.m_Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            IPowerUp PowerUp = other.GetComponent<IPowerUp>(); //get whatever powerup script the thing it collided with has

            //get the duration and value associated with the power up
            float PowUpDur = PowerUp.GetDuration();
            float PowUpVal = PowerUp.GetValue();

            if (PowerUp is SpeedUp) // toggle speed up effects on
            {
                m_IsSpeedUp = true;
                m_SpeedDur = PowUpDur;
                m_SpeedMult = PowUpVal;
                if(m_IsSpeedDown)
                {
                    m_IsSpeedDown = false; //toggle off previous speed down
                }
            }

            else if (PowerUp is SpeedDown)
            {
                m_IsSpeedDown = true;
                m_SpeedDur = PowUpDur;
                if(m_IsSpeedUp)
                {
                    m_IsSpeedUp = false; //toggle off previous speed up
                }
            }

            else if (PowerUp is InvertControls)
            {
                m_IsInverted = true;
                m_InvertDur = PowUpDur;
            }

            else if (PowerUp is BoostMultiplier)
            {
                m_IsBoostMult = true;
                m_BoostMultDur = PowUpDur;
                m_BoostMult = PowUpVal;
                
            }

            else if (PowerUp is BoostBonus)
            {
                // rn this is triggering twice for some reason so I'm just going to divide the value by 2 as a temporary workaround until I figure out whats happening
                if (m_IsBoostMult)
                {
                    //if multiplier is on, multiplies the amt they get from the boost bonuses too
                    Debug.Log("boostmult reached when picking up boost bonus");
                    m_PlayerMovement.m_Boost += PowUpVal/2f * m_BoostMult;
                }
                else
                {
                    m_PlayerMovement.m_Boost += PowUpVal/2f;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_IsBoostMult);
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
                Debug.Log(newSpeed);
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
