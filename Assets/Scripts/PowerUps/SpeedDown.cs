using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : IPowerUp
{
    [Tooltip("How many times slower the car will go.")]
    public float m_SlowMultiplier = 2f;

    [Tooltip("How long the Speed Down power up will be effecting the player.")]
    public float m_EffectDuration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CarPowerUpEffects playerPowEff = other.GetComponent<CarPowerUpEffects>();
            if (playerPowEff)
            { // if has script -> apply effects
                Destroy(gameObject);
                playerPowEff.m_IsSpeedDown = true;
                playerPowEff.m_IsSpeedUp = false;
                playerPowEff.m_SpeedDur = m_EffectDuration;
                playerPowEff.m_SpeedMult = m_SlowMultiplier;
            }
        }
    }

    public float GetValue()
    {
        return m_SlowMultiplier;
    }

    public float GetDuration()
    {
        return m_EffectDuration;
    }
}
