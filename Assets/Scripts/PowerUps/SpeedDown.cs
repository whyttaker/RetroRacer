using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour, IPowerUp
{
    [Tooltip("How many times slower the car will go.")]
    public float m_SlowMultiplier = 2f;

    [Tooltip("How long the Speed Down power up will be effecting the player.")]
    public float m_EffectDuration = 3f;

    [Tooltip("How long the Speed Down power up will live.")]
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
        return m_SlowMultiplier;
    }

    public float GetDuration()
    {
        return m_EffectDuration;
    }
}
