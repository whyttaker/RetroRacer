using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMultiplier : MonoBehaviour, IPowerUp
{
    [Tooltip("How many times more boost points the car will recieve during the power up's duration.")]
    public float m_BoostMultiplier = 2f;

    [Tooltip("How long the Boost Multiplier power up will be effecting the player.")]
    public float m_EffectDuration = 30f;

    [Tooltip("How long the Boost Multiplier power up will live.")]
    public float m_MaxLifeTime = 9999f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Destroy(gameObject);
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
