using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    public float rightMoves = 0;
    public float leftMoves = 0;

    public GameObject currentCar;


    public GameObject SpeedSlider;
    public GameObject AccelSlider;
    public GameObject HandleSlider;
    public CinemachineVirtualCamera VCam;

    //public Transform[] cars;
    public CarMovement[] Car_Array;
    int carIndex = 0;

    public Camera CarCam;

    // Start is called before the first frame update
    void Start()
    {
        carIndex = Car_Array.Length/2;
        CarCam.enabled = false;

    }

    void Active()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if(Car_Array.Length == 0){
        //     //Car_Array = (CarMovement[])currentCar.GetComponentsInChildren(typeof(CarMovement));
        //     carIndex = Car_Array.Length/2;
        //     int index = 0;
        //     foreach (CarMovement car in Car_Array)
        //     {
        //         index++;
        //         Debug.Log("Car number: " + index + " " + car.m_Speed);

        //     }
        // }
    }

    public void CameraAdvance()
    {
        Camera.main.gameObject.transform.Translate(-16, -5, 39);
        Camera.main.gameObject.transform.Rotate(5, 51, 0);
    }

    public void CameraMoveLeft()
    {
        float z = Camera.main.gameObject.transform.position.z;
        float x = Camera.main.gameObject.transform.position.x;
        float y = Camera.main.gameObject.transform.position.y;
        Debug.Log("Current X: " + x + " Current Y: " + y + " Current Z: " + z);
        Debug.Log("cararraylen = " + Car_Array.Length );
        if (carIndex < Car_Array.Length-1)
        {
            Camera.main.gameObject.transform.Translate(-12, 0, 0);
            carIndex++;
        }
        updateSliders();
    }

    public void CameraMoveRight()
    {
        float z = Camera.main.gameObject.transform.position.z;
        float x = Camera.main.gameObject.transform.position.x;
        float y = Camera.main.gameObject.transform.position.y;
        Debug.Log("Current X: " + x + " Current Y: " + y + " Current Z: " + z);
        //Debug.Log("cararraylen = " + Car_Array.Length );
        if (carIndex > 0)
        {
            Camera.main.gameObject.transform.Translate(12, 0, 0);
            carIndex--;
        }
        updateSliders();
    }


    public void updateSliders()
    {
        //float speedx = SpeedSlider.transform.GetChild(2).GetChild(0).position.x;
        float speedy = SpeedSlider.transform.GetChild(2).GetChild(0).position.y;
        float speedz = SpeedSlider.transform.GetChild(2).GetChild(0).position.z;
        SpeedSlider.transform.GetChild(2).GetChild(0).position = new Vector3 (1050 + Car_Array[carIndex].m_Speed/2,speedy,speedz);
        //float accx = AccelSlider.transform.GetChild(2).GetChild(0).position.x;
        float accy = AccelSlider.transform.GetChild(2).GetChild(0).position.y;
        float accz = AccelSlider.transform.GetChild(2).GetChild(0).position.z;
        AccelSlider.transform.GetChild(2).GetChild(0).position = new Vector3 (1050 + Car_Array[carIndex].m_Accel/2,accy,accz);
        //float handx = HandleSlider.transform.GetChild(2).GetChild(0).position.x;
        float handy = HandleSlider.transform.GetChild(2).GetChild(0).position.y;
        float handz = HandleSlider.transform.GetChild(2).GetChild(0).position.z;
        HandleSlider.transform.GetChild(2).GetChild(0).position = new Vector3(1050 + Car_Array[carIndex].m_Handling/2,handy,handz);


        // float speedx = SpeedSlider.transform.GetChild(1).position.x;
        // float speedy = SpeedSlider.transform.GetChild(1).position.y;
        // float speedz = SpeedSlider.transform.GetChild(1).position.z;
        // SpeedSlider.transform.GetChild(1).position = new Vector3 (600 + Car_Array[carIndex].m_Speed/2,speedy,speedz);
        // float accx = AccelSlider.transform.GetChild(1).position.x;
        // float accy = AccelSlider.transform.GetChild(1).position.y;
        // float accz = AccelSlider.transform.GetChild(1).position.z;
        // AccelSlider.transform.GetChild(1).position = new Vector3 (600 + Car_Array[carIndex].m_Accel/2,accy,accz);
        // float handx = HandleSlider.transform.GetChild(1).position.x;
        // float handy = HandleSlider.transform.GetChild(1).position.y;
        // float handz = HandleSlider.transform.GetChild(1).position.z;
        // HandleSlider.transform.GetChild(1).position = new Vector3(600 + Car_Array[carIndex].m_Handling/2,handy,handz);
    }

    public void SelectCar()
    {

        //Select the car at Car_Array[index], then delete all other cars

        GameObject selectedCar = Car_Array[carIndex].transform.parent.gameObject;

        //Delete cars
        for (int i=Car_Array.Length-1; i >=0 ; i--)
        {
            if(i != carIndex)
            {
                Debug.Log(Car_Array[i]);
                Destroy(Car_Array[i].transform.gameObject, 0);
            }
            
        }
        
        CarCam.enabled = true;
        // VCam.Follow = cars[0];
        // VCam.LookAt = cars[0];
        this.gameObject.SetActive(false);
        //Move cam
        // Camera.main.gameObject.transform.position = new Vector3(Car_Array[0].transform.gameObject.transform.position.x + 40,
        //                                                         Car_Array[0].transform.gameObject.transform.position.y + 77,
        //                                                         Car_Array[0].transform.gameObject.transform.position.z + 1);
        // Camera.main.gameObject.transform.Rotate(65, 180, 0);

    }

}
