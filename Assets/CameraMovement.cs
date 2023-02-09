using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraAdvance()
    {
        
        Camera.main.gameObject.transform.Translate(-16, -5, 39);

        Camera.main.gameObject.transform.Rotate(5, 51, 0);




    }

    public void CameraMoveLeft()
    {

        Camera.main.gameObject.transform.Translate(0, 0, -12);
    }

    public void CameraMoveRight()
    {
        Camera.main.gameObject.transform.Translate(0, 0, 12);
    }

}
