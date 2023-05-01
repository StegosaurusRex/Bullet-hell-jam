using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI; 

public class CharacterFlying : MonoBehaviour
{

    [Header("Variables")]
    [SerializeField] float m_maxSpeed = 4.5f;

    private Animator m_animator;
    
    private Sensor_Character m_groundSensor;
    private bool m_grounded = false;
    private bool m_moving = false;
    public bool m_facingRight = false;
    private float m_disableMovementTimer = 0.0f;
    public List<GameObject> unlockedWeapons; // List of closed cannons
    public GameObject[] allWeapons; // All guns
    public Image weaponsIcon; // Cannon icon

    void Start()
    {
        m_animator = GetComponent<Animator>();
        
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Character>();
    }


    void Update()
    {

        // Decrease timer that disables input movement. Used when attacking
        m_disableMovementTimer -= Time.deltaTime;

        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = 0.0f;

        if (m_disableMovementTimer < 0.0f)
            inputX = Input.GetAxis("Horizontal");

        // GetAxisRaw returns either -1, 0 or 1
        float inputRaw = Input.GetAxisRaw("Horizontal");
        // Check if current move input is larger than 0 and the move direction is equal to the characters facing direction
        if (Mathf.Abs(inputRaw) > Mathf.Epsilon)
            m_moving = true;

        else
            m_moving = false;

        // Swap direction of sprite depending on move direction
        if (!m_facingRight && inputRaw > 0)
        {
            Flip();
            //m_facingDirection = 1;
        }

        else if (m_facingRight && inputRaw < 0)
        {
            Flip();
            //m_facingDirection = -1;
        }

        // SlowDownSpeed helps decelerate the characters when stopping
        float SlowDownSpeed = m_moving ? 1.0f : 0.5f;
        // Set movement
        

        // Set AirSpeed in animator
        

        //Death
        //if (Input.GetKeyDown("e"))
            //m_animator.SetTrigger("Death");

        //Run
        if (m_moving)
            m_animator.SetInteger("AnimState", 1);

        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Run
        else if (m_moving)
            m_animator.SetInteger("AnimState", 1);


        //Idle
        else
            m_animator.SetInteger("AnimState", 0);


    }


   


    public void Flip() // Player turn
    {
        m_facingRight = !m_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }



}