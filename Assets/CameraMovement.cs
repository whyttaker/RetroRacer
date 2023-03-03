using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public float rightMoves = 0;
    public float leftMoves = 0;
    public Vector3 CameraOrigin = new Vector3(0, 0, 0);


    public GameObject currentCar;

    public Slider SpeedSlider;
    public Slider AccelSlider;
    public Slider HandleSlider;



    public CinemachineVirtualCamera VCam;

    //public Transform[] cars;
    public CarMovement[] Car_Array;
    int carIndex = 0;

    public Camera CarCam;

    // Start is called before the first frame update
    void Start()
    {
        carIndex = Car_Array.Length/2;
    }

    void Active()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CameraAdvance()
    {
        
        Camera.main.gameObject.transform.Translate(-16, -5, 51);
        Camera.main.gameObject.transform.Rotate(5, 51, 0);
    }

    public void CameraReverse()
    {
        Camera.main.gameObject.transform.Translate(CameraOrigin);
        Camera.main.gameObject.transform.Translate(16, 5, -39);
        Camera.main.gameObject.transform.Rotate(-5, -51, 0);
    }

    public void CameraMoveLeft()
    {
        float z = Camera.main.gameObject.transform.position.z;
        float x = Camera.main.gameObject.transform.position.x;
        float y = Camera.main.gameObject.transform.position.y;
        Debug.Log("Current X: " + x + " Current Y: " + y + " Current Z: " + z);
        Debug.Log("cararraylen = " + Car_Array.Length );
        if (carIndex > 0)
        {
            Camera.main.gameObject.transform.Translate(-12, 0, 0);
            CameraOrigin.x += 12;
            carIndex--;
        }
        updateSliders();
    }

    public void CameraMoveRight()
    {
        float z = Camera.main.gameObject.transform.position.z;
        float x = Camera.main.gameObject.transform.position.x;
        float y = Camera.main.gameObject.transform.position.y;
        Debug.Log("Current X: " + x + " Current Y: " + y + " Current Z: " + z);
        Debug.Log("cararraylen = " + Car_Array.Length );
        if (carIndex < Car_Array.Length-1)
        {
            Camera.main.gameObject.transform.Translate(12, 0, 0);
            CameraOrigin.x -= 12;
            carIndex++;
        }
        updateSliders();
    }


    public void updateSliders()
    {

        SpeedSlider.value = Car_Array[carIndex].m_Speed;
        AccelSlider.value = Car_Array[carIndex].m_Accel;
        HandleSlider.value = Car_Array[carIndex].m_Handling;

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
                Car_Array[i].transform.gameObject.SetActive(false);
            }
            
        }
        
        CarCam.enabled = true;
        VCam.Follow = Car_Array[carIndex].transform;
        VCam.LookAt = Car_Array[carIndex].transform;
        this.gameObject.SetActive(false);
        //Move cam
        // Camera.main.gameObject.transform.position = new Vector3(Car_Array[0].transform.gameObject.transform.position.x + 40,
        //                                                         Car_Array[0].transform.gameObject.transform.position.y + 77,
        //                                                         Car_Array[0].transform.gameObject.transform.position.z + 1);
        // Camera.main.gameObject.transform.Rotate(65, 180, 0);

    }

    public void TwoPLayerSelectCar()
    {

        //Select the car at Car_Array[index], then delete all other cars

        GameObject selectedCar = Car_Array[carIndex].transform.parent.gameObject;
        if(carIndex == 0)
        {
            GameObject secondSelectedCar = Car_Array[carIndex + 1].transform.parent.gameObject;

        }
        else
        {
            GameObject secondSelectedCar = Car_Array[0].transform.parent.gameObject;

        }



        //Delete all other cars
        for (int i = Car_Array.Length - 1; i >= 0; i--)
        {
            if (i != carIndex && i != 0)
            {
                Debug.Log(Car_Array[i]);
                Destroy(Car_Array[i].transform.gameObject, 0);
            }

        }

        CarCam.enabled = true;
        VCam.LookAt = Car_Array[carIndex].transform;
        VCam.Follow = Car_Array[carIndex].transform;
        Car_Array[carIndex].keyInIgnition = false;
    }

}
