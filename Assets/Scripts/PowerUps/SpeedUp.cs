using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour, IPowerUp
{   
    [Tooltip("How many times faster the car will go.")]
    public float m_SpeedMultiplier = 2f; 

    [Tooltip("How long the Speed Up power up will be effecting the player.")]
    public float m_EffectDuration = 3f; 

    [Tooltip("How long the Speed Up power up will live.")]
    public float m_MaxLifeTime = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            Destroy(gameObject);
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
