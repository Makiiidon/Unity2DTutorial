using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Apple;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private InputManager m_inputManager;

    private Animator m_anim;

    [SerializeField] private float m_speed = 250f;
    //[SerializeField] private SpriteRenderer m_sprite;

    bool m_isFacingLeft = true;

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

        if (m_rb.velocity != Vector2.zero)
        {
            m_anim.SetBool("IsWalking", true);
            Debug.Log("Working");

        }
        else if (m_rb.velocity == Vector2.zero)
        {
            m_anim.SetBool("IsWalking", false);
        }

        //// Set destination point
        //Vector2 direction = destination - currentPos;

        //if (m_isFacingLeft && direction.x > 0)
        //{
        //    m_anim.SetTrigger("Flip");

        //}
        //else if (!m_isFacingLeft && direction.x < 0)
        //{
        //    m_anim.SetTrigger("Flip");

        //}


        // Alternative for movement, but is more Physics based
        //m_rb.AddForce(m_inputManager.GetMoveInput().normalized * m_speed, ForceMode2D.Force);

        // Explore the different ways to move rigidbodies
    }

}
