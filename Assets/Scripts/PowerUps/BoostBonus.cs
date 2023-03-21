using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBonus : IPowerUp
{
    [Tooltip("How many boost points the car will earn when picking up a Boost Bonus power up")] 
    //might want to change this to be a percentage of the bar gained later
    public float m_BoostBonus = 30f;

    private float m_EffectDuration = 0f; // instant so duration doesn't matter for this power up

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CarPowerUpEffects playerPowEff = other.GetComponent<CarPowerUpEffects>();
            if (playerPowEff)
            { //if has script -> apply power up effects
                Destroy(gameObject);
                playerPowEff.m_PlayerMovement.m_Boost += m_BoostBonus * playerPowEff.m_BoostMult;
            }
           
        }
    }

    public float GetValue()
    {
        return m_BoostBonus;
    }

    public float GetDuration()
    {
        return m_EffectDuration;
    }
}
