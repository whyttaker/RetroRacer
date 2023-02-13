using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUp
{

    float GetValue(); // return the value associated with the power up (ex: if speed up, how much faster to go)

    float GetDuration(); //return how long the power up affects the user in seconds

}
