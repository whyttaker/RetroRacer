using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    public GameObject gameOverScreen;
  
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag == "Player")
        {
            Debug.Log("Finished!");
            gameOverScreen.SetActive(true);
        }
    }
}
