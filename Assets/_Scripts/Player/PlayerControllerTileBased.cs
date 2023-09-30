using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTileBased : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private InputManager m_inputManager;

    [SerializeField] private float m_tileMovement = 1f;

    [SerializeField] private float m_moveInterval = 1f;
    private float m_endTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the Reference of the input manager
        m_inputManager = InputManager.instance;
        m_rb = GetComponent<Rigidbody2D>();
        m_endTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_inputManager.GetMoveInput() != Vector2.zero)
        {
            if (m_endTime < Time.time)
            {
                Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y);
                m_rb.MovePosition(pos + m_inputManager.GetMoveInput());
                m_endTime += m_moveInterval;
            }
            
        }
    }
}
