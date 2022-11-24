using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineDelete : MonoBehaviour 
{
    public LayerMask line;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, line);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    public void DeleteAll()
    {
        GameObject[] strings = GameObject.FindGameObjectsWithTag("String");

        foreach (GameObject gameObject in strings)
        {
            Destroy(gameObject);
        }
    }
}
