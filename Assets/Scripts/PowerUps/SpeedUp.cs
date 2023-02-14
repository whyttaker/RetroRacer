using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour, IPowerUp
{   
    [Tooltip("How many times faster the car will go.")]
    public float SpeedMultiplier = 2f; 

    [Tooltip("How long the power up will be effecting the player.")]
    public float EffectDuration = 3f; 

    [Tooltip("How long the Speed Up power up will live.")]
    public float MaxLifeTime = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, MaxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            Destroy(gameObject);
    }

    public float GetValue()
    {
        return SpeedMultiplier;
    }

    public float GetDuration()
    {
        return EffectDuration;
    }
}
