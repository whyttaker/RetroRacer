using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour{
    public PathCreator pathCreator;

    public GameObject obj;
    private float speed = 90;

    
     float distanceTravelled;
     void Update() {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        var distanceBetweenObjects = Vector3.Distance(transform.position, obj.transform.position);
        if(distanceBetweenObjects > 50){
            speed = 180;
        }else if(distanceBetweenObjects > 100){
            speed = 90;
        }else{
            speed = 140;
        }
    }
}
