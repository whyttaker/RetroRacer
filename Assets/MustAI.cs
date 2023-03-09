using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MustAI : MonoBehaviour
{

    // https://stackoverflow.com/questions/30056471/how-to-make-the-script-wait-sleep-in-a-simple-way-in-unity
    // Start is called before the first frame update


    public PathCreator pathCreator;

    public GameObject obj;
    private float speed = 90;
    
     float distanceTravelled;


    void Start(){
        this.gameObject.SetActive(false);
    }
    void OnEnable()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
    }


     void Update() {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        var distanceBetweenObjects = Vector3.Distance(transform.position, obj.transform.position);

        if(distanceBetweenObjects < 30){
            speed = 0;
        }
        if(distanceBetweenObjects <= 50){
            speed = 70;
        }else if(distanceBetweenObjects > 50){
            speed = 200;
        }
        Debug.Log(distanceBetweenObjects);
        
    }
}
