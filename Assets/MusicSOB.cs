using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MusicSOB : MonoBehaviour
{
    public static MusicSOB instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}