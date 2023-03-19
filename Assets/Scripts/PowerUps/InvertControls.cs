using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertControls : IPowerUp
{
    [Tooltip("How long the Invert Controls power up will be effecting the player.")]
    public float m_EffectDuration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            CarPowerUpEffects playerPowEff = gameObject.GetComponent<CarPowerUpEffects>();
            playerPowEff.m_IsInverted = true;
            playerPowEff.m_InvertDur = m_EffectDuration;
        }
    }

    public float GetValue()
    {
        return 0f; // here to satisfy the interface lol
        // I originally thought of using a -1 multiplier to invert the controls but then I remembered I could just use a bool instead
    }

    public float GetDuration()
    {
        return m_EffectDuration;
    }
}
