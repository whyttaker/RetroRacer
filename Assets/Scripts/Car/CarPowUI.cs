using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarPowUI : MonoBehaviour
{
    // Start is called before the first frame update

    public CarMovement playerMovement;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI invertedText;
    public TextMeshProUGUI boostMultText;

    public void Awake()
    {
        playerMovement = GetComponent<CarMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(speedText)
        { //if has a text box associated w the speed
            speedText.text = playerMovement.m_Speed.ToString();
        }

        if (invertedText)
        { //if has text box associated w inverted controls
            if (playerMovement.m_Inverted)
            {
                invertedText.text = "! INVERTED !";
            }
            else
            {
                invertedText.text = "";
            }
        }

        if (boostMultText)
        { // if has a text box associated w the boost multiplier
            if (playerMovement.m_BoostMult > 1f)
            {
                boostMultText.text = "2x Boost";
            }
            else
            {
                boostMultText.text = "";
            }
        }
    }
}
