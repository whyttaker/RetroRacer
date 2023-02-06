using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEscape : MonoBehaviour
{

    public GameObject SettingsMenu;
    public GameObject Title;
    public GameObject SettingsButton;
    public GameObject PlayButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsMenu.SetActive(!SettingsMenu.activeSelf);

            SettingsButton.SetActive(!SettingsMenu.activeSelf);
            Title.SetActive(!SettingsMenu.activeSelf);
            PlayButton.SetActive(!SettingsMenu.activeSelf);
           


        }
        
    }
}
