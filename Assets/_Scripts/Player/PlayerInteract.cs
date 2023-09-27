using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private InputManager m_inputManager;

    [SerializeField] private float m_radius = 1f;
    [SerializeField] private LayerMask m_interactableLayer;
    [SerializeField] private string m_NPCTag = "NPC";

    // Start is called before the first frame update
    void Start()
    {
        m_inputManager = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_inputManager.IsSelect()) 
        {
            // Place all of the game objects with the same layer as "m_interactableLayer"
            Collider2D[] interactables = Physics2D.OverlapCircleAll(this.transform.position, m_radius, m_interactableLayer);

            // Check all of the gameObjects in interactables then call the DisplayMessage() Function
            foreach (Collider2D interactable in interactables) 
            {
                interactable.GetComponent<NPCInteraction>().DisplayMessage();
            }
        }
    }

    // Function used for drawing gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, m_radius);
    }

    // Function used for trigger collisions
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(m_NPCTag)) return;       
        other.gameObject.GetComponent<NPCInteraction>().DisplayMessage();
    }
}
