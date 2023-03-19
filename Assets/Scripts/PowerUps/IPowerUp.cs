using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPowerUp : MonoBehaviour
{
    [Tooltip("How long a default power up will live.")]
    public float m_MaxLifeTime = 999f;

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

}
