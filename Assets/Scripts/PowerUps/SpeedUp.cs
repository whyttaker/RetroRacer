using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : IPowerUp
{   
    [Tooltip("How many times faster the car will go.")]
    public float m_SpeedMultiplier = 2f; 

    [Tooltip("How long the Speed Up power up will be effecting the player.")]
    public float m_EffectDuration = 3f; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            CarPowerUpEffects playerPowEff = other.GetComponent<CarPowerUpEffects>();
            playerPowEff.m_IsSpeedUp = true;
            playerPowEff.m_IsSpeedDown = false;
            playerPowEff.m_SpeedDur = m_EffectDuration;
            playerPowEff.m_SpeedMult = m_SpeedMultiplier;
        }
    }

    public float GetValue()
    {
        return m_SpeedMultiplier;
    }

    public float GetDuration()
    {
        return m_EffectDuration;
    }
}
