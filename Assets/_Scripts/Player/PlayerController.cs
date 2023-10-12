using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private InputManager m_inputManager;

    private Animator m_anim;

    [SerializeField] private float m_speed = 250f;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the Reference of the input manager
        m_inputManager = InputManager.instance;
        m_rb = GetComponent<Rigidbody2D>(); 
        m_anim = GetComponent<Animator>();
    }


    private void Update()
    {
        
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }


    // Made this into a seperate function for better readability
    private void Move() 
    {
        // One of many Computations for rigidbody movement
        m_rb.velocity = m_inputManager.GetMoveInput().normalized * m_speed;
        
        if (m_inputManager.GetMoveInput() == Vector2.zero)
        {
            m_anim.SetBool("IsMoving", false);
        }
        else
        {
            m_anim.SetBool("IsMoving", true);
        }
        // Alternative for movement, but is more Physics based
        //m_rb.AddForce(m_inputManager.GetMoveInput().normalized * m_speed, ForceMode2D.Force);

        // Explore the different ways to move rigidbodies
    }
}
