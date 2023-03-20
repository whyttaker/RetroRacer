using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    public GameObject gameOverScreen;
    public GameObject player1Finish;
    public GameObject player2Finish;

  
  
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            Debug.Log("Finished!");
            //Debug.Log(other.GetComponentInParent<CarMovement>().m_PlayerNumber);
            int screenToDisplay = other.GetComponentInParent<CarMovement>().m_PlayerNumber;
            gameOverScreen.SetActive(true);


            if (screenToDisplay == 1)
            {
                player1Finish.SetActive(true);
                Debug.Log("Player 1 Won");

            }
            else
            {
                player2Finish.SetActive(true);
                Debug.Log("Player 2 Won");
            }

            
        }
    }
}
