using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour
{
    public LayerMask draggable;
    public GameObject selectedObject;
    public Rigidbody2D rigidBody;
    public bool isDragging;
    public float Speed;    

    private void Start()
    {
        isDragging = false;        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, draggable);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                selectedObject = hit.collider.gameObject;                
                isDragging = true;
            }

            if (isDragging == true)
            {
                Vector3 pos = mousePos();                

                if (pos.x > -6.5f && pos.x < 6.5f && pos.y > -4.8f && pos.y < 4.8f)
                {
                    selectedObject.transform.position = pos;
                }
                

            }
                        
                        
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            selectedObject = null;
            rigidBody = null;
        } 
    }

    Vector3 mousePos()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));   
    }

}
