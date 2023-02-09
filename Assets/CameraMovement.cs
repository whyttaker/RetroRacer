using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rightMoves = 0;
    public float leftMoves = 0;
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
        float z = Camera.main.gameObject.transform.position.z;
        float x = Camera.main.gameObject.transform.position.x;
        float y = Camera.main.gameObject.transform.position.y;
        Debug.Log("Current X: " + x + " Current Y: " + y + " Current Z: " + z);
        if (leftMoves < 2)
        {

            Camera.main.gameObject.transform.Translate(-12, 0, 0);
            leftMoves++;

            
             rightMoves--;
       
        }
    }

    public void CameraMoveRight()
    {
        float z = Camera.main.gameObject.transform.position.z;
        float x = Camera.main.gameObject.transform.position.x;
        float y = Camera.main.gameObject.transform.position.y;
        Debug.Log("Current X: " + x + " Current Y: " + y + " Current Z: " + z);
        if (rightMoves < 2)
        {
            Camera.main.gameObject.transform.Translate(12, 0, 0);
            rightMoves++;
            
            leftMoves--;
            

        }
    }

}
