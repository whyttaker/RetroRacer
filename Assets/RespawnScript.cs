using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    //find out how to 
    public Camera cameraMov;

    //public Transform player;
    [SerializeField] public Transform respawnPoint;
    //private Quaternion originalRotationValue;

    // void Start(){
    //     player = cameraMov.GetComponent<CameraMovement>().currentCar.transform;
    //     originalRotationValue = player.transform.rotation;
    // }

    //Some how, Some way, this does not work
    void OnTriggerEnter(Collider other){
        cameraMov.GetComponent<CameraMovement>().Respawn(respawnPoint);
    }
}
