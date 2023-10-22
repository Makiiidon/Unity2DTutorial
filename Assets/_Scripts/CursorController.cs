using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    [SerializeField] SpriteRenderer sprite;

    [SerializeField] Sprite[] cursors;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += Camera.main.nearClipPlane;
        this.gameObject.transform.position = mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider == null)
        {
            sprite.sprite = cursors[0];
        }
        else if (hit.collider.gameObject.CompareTag("NPC"))
        {
            sprite.sprite = cursors[1];
        }
        
    }
}
