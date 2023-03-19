using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMultiplier : IPowerUp
{
    [Tooltip("How many times more boost points the car will recieve during the power up's duration.")]
    public float m_BoostMultiplier = 2f;

    [Tooltip("How long the Boost Multiplier power up will be effecting the player.")]
    public float m_EffectDuration = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            CarPowerUpEffects playerPowEff = other.GetComponent<CarPowerUpEffects>();
            playerPowEff.m_IsBoostMult = true;
            playerPowEff.m_BoostMult = m_BoostMultiplier;
            playerPowEff.m_BoostMultDur = m_EffectDuration;
        }
    }

    public float GetValue()
    {
        return m_BoostMultiplier;
    }

    public float GetDuration()
    {
        return m_EffectDuration;
    }
}
