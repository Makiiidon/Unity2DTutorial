using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Vector2 m_moveInput;
    [SerializeField] private KeyCode m_select = KeyCode.Mouse0;
    bool m_selectRequest = false;

    public static InputManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        m_moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        m_selectRequest = Input.GetKeyDown(m_select);
    }


    // Getters
    public Vector2 GetMoveInput() { return m_moveInput; }
    public bool IsSelect() {  return m_selectRequest; }
}
