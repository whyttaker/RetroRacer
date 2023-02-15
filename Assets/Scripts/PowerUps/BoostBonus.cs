using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBonus : MonoBehaviour, IPowerUp
{
    [Tooltip("How many boost points the car will earn when picking up a Boost Bonus power up")] 
    //might want to change this to be a percentage of the bar gained later
    public float m_BoostBonus = 30f;

    private float m_EffectDuration = 0f; // instant so duration doesn't matter for this power up

    [Tooltip("How long the Boost Bonus power up will live.")]
    public float m_MaxLifeTime = 5f;

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
        return m_BoostBonus;
    }

    public float GetDuration()
    {
        return m_EffectDuration;
    }
}
