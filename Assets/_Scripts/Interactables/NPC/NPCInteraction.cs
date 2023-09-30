using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] string m_message = "Hello World!";
    [SerializeField] LayerMask m_playerLayer;

    public void DisplayMessage()
    {
        Debug.Log(m_message);
    }

}
