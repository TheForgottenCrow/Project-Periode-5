﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
<<<<<<< HEAD:RobotsWow/Assets/Resources/Scripts/Jefta/Player.cs
public class Player : MonoBehaviour {

    [SerializeField]
<<<<<<< HEAD
    private float m_JumpStrength, m_JumpTime, m_MoveSpeed;
    
	
	void Start ()
=======
    KeyCode m_KeyUp, m_KeyDown, m_KeyLeft, m_KeyRight, m_KeyJump;

    [SerializeField]
    float m_WalkSpeed, m_JumpStrength, m_NormalGravityMultiplyer, m_HeavyGrafityMultiplyer;

    Vector3 m_PlayerVelocity;
    e_Direction m_Direction;
    Rigidbody m_Rigidbody;

    void Start ()
>>>>>>> DeveloperGeneral
=======
=======
>>>>>>> DeveloperGeneral
enum EPlayerState
{
    Idle = 0,
    Runnig
}

<<<<<<< HEAD:RobotsWow/Assets/Resources/Scripts/Jefta/PlayerVoorKipje.cs

=======
>>>>>>> KyleVanDenBoom:RobotsWow/Assets/Resources/Scripts/Jefta/PlayerVoorKipje.cs
public class PlayerVoorKipje : MonoBehaviour
{
    [Header("Physics"), Space()]
    [SerializeField] private float m_JumpStrength;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_FallGravity;
    [SerializeField] private float m_LowJumpGravity;
    [SerializeField] private LayerMask m_GroundLayer;

    private float m_XVelocity;
    private float m_ZVelocity;

    private Vector3 m_DirectionMem;


    private Rigidbody m_RB;
    private CapsuleCollider m_Col;
    private Animator m_Animator;

    [Space()]
    [SerializeField, Header("Debug")]
    private Vector3 d_Velocity;


    private void Awake()
<<<<<<< HEAD
>>>>>>> DeveloperGeneral:RobotsWow/Assets/Resources/Scripts/Jefta/PlayerVoorKipje.cs
=======
>>>>>>> DeveloperGeneral
    {
        m_RB = GetComponent<Rigidbody>();
        m_Col = GetComponent<CapsuleCollider>();
        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Animator
        if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        { 
            m_Animator.SetInteger("State", (int)EPlayerState.Idle);
        }
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && IsGrounded())
        {
            m_Animator.SetInteger("State", (int)EPlayerState.Runnig);
        }

       

        //Horizontal and Verticle movement

        m_XVelocity = Input.GetAxis("Horizontal") * m_MoveSpeed;
        m_ZVelocity = Input.GetAxis("Vertical") * m_MoveSpeed;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            m_RB.velocity += Vector3.up * m_JumpStrength;
        }

    }


    private void LateUpdate()
    {
        //Update RidgidBody
        Vector3 v3 = m_RB.velocity;
        v3.x = m_XVelocity;
        v3.z = m_ZVelocity;

        if (m_RB.velocity.y <= 0)
        {
            v3 += Vector3.up * Physics.gravity.y * (m_FallGravity - 1) * Time.deltaTime;
        }
        else if (m_RB.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            v3 += Vector3.up * Physics.gravity.y * (m_LowJumpGravity - 1) * Time.deltaTime;
        }

        d_Velocity = m_RB.velocity = v3;

        //Turn Arround
        
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(v3.x, 0, v3.z));
            transform.Rotate(Vector3.up, 90);
        }
        
    }

    public bool IsGrounded()
    {
        return (Physics.CheckCapsule(m_Col.bounds.center, new Vector3(m_Col.bounds.center.x, m_Col.bounds.min.y, m_Col.bounds.center.z), m_Col.radius * 0.9f, m_GroundLayer)) ; 
    }

}
    