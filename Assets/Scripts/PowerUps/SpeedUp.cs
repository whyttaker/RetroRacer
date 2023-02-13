using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour, IPowerUp
{
    public float SpeedMultiplier = 2f; //how many times faster the car will go
    public float EffectDuration = 3f; //how long the power up will be effecting the player
    public float MaxLifeTime = 3f; //how long the power up will be on the stage

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
