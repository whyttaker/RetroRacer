using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyotaMovement : CarMovement
{

    public ToyotaMovement()
    {
        m_Speed = 4;
        m_Handling = 1;
        m_Accel = 1;
    }
    public int m_PlayerNumber = 1;
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    public float m_Accel = 50;
    public float m_Handling = 0;
    // public AudioSource m_MovementAudio;    
    // public AudioClip m_EngineIdling;       
    // public AudioClip m_EngineDriving;      
    public float m_PitchRange = 0.2f;


    public string m_MovementAxisName;
    public string m_TurnAxisName;
    public Rigidbody m_Rigidbody;
    public float m_MovementInputValue;
    public float m_TurnInputValue;
    public float m_OriginalPitch;


    public void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    public void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    public void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }


    public void Start()
    {
        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";

        //m_OriginalPitch = m_MovementAudio.pitch;
    }


    public void Update()
    {
        Debug.Log("Ran the update function");
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        Debug.Log("Value is: " + m_MovementInputValue);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
        //EngineAudio();
    }


    // private void EngineAudio()
    // {
    //     if(Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f)
    //     {
    //         if(m_MovementAudio.clip == m_EngineDriving){
    //             m_MovementAudio.clip = m_EngineIdling;
    //             m_MovementAudio.pitch = Random.Range(m_OriginalPitch-m_PitchRange, m_OriginalPitch+m_PitchRange);
    //             m_MovementAudio.Play();
    //         }
    //     }else{
    //         if(m_MovementAudio.clip == m_EngineIdling){
    //             m_MovementAudio.clip = m_EngineDriving;
    //             m_MovementAudio.pitch = Random.Range(m_OriginalPitch-m_PitchRange, m_OriginalPitch+m_PitchRange);
    //             m_MovementAudio.Play();
    //         }
    //     }
    // }


    public void FixedUpdate()
    {
        // Move and turn the tank.
        Move();
        Turn();
    }


    public void Move()
    {
        // Adjust the position of the tank based on the player's input.
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }


    public void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

}
