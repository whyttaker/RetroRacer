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
    public CinemachineVirtualCamera VCamP1;
    public CinemachineVirtualCamera VCamP2;
    

    public CarMovement[] Car_Array;

    int carIndex = 0;

    public Camera CarCam;
    public Camera P1Cam;
    public Camera P2Cam;

    // Start is called before the first frame update
    void Start()
    {
        carIndex = Car_Array.Length/2;
        //P2Cam.enabled = false;
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

    public GameObject getCar(){
        return currentCar;
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
        VCamP2.enabled = false;
        P2Cam.enabled = false;
        CarCam.enabled = true;

        //Select the car at Car_Array[index], then delete all other cars

        GameObject selectedCar = Car_Array[carIndex].transform.parent.gameObject;
        //Debug.Log("We  selected this jawn");

        //Delete cars
        for (int i=Car_Array.Length-1; i >=0 ; i--)
        {
            if(i != carIndex)
            {
                Car_Array[i].transform.gameObject.SetActive(false);
            }
        }
      
        // VCamP2.enabled = false;
        
        // P2Cam.enabled = false;
        VCam.Follow = Car_Array[carIndex].transform;
        VCam.LookAt = Car_Array[carIndex].transform;

        this.gameObject.SetActive(false);


    }

    public void TwoPLayerSelectCar()
    {
        //GameObject selectedCar = Car_Array[2].transform.parent.gameObject;
        GameObject secondSelectedCar = Car_Array[4].transform.parent.gameObject;


        //Delete all other cars
        for (int i = Car_Array.Length - 1; i >= 0; i--)
        {
            if (i != 3 && i != 4)
            {
                Debug.Log(Car_Array[i]);
                Car_Array[i].transform.gameObject.SetActive(false);
            }

        }

        P1Cam.rect = new Rect(0, 0, 0.5f, 1);

        VCam.enabled = false;
        VCamP1.enabled = false;
        P1Cam.enabled = true;
        VCamP1.enabled = true;
        P2Cam.gameObject.SetActive(true);
        P2Cam.enabled = true;


        this.gameObject.SetActive(false);
        

        var transform = Car_Array[3].transform;
        var parent = transform.parent;
        var gameobject = parent.gameObject;
        var toyotaStats = gameObject.GetComponent<ToyotaStats>();
        Debug.Log(toyotaStats);

        Car_Array[3].m_PlayerNumber = 2;


        
    }
    

}
