using Fungus;
using MoonSharp.Interpreter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public GameObject drawingPrefab;
    private Vector2 Position;
    private Vector2 startPosition;    
    public int K = 0;
    private Color[] colors = { Color.red, Color.black, Color.grey, Color.white };
    public Image colorIndicator;
    private EdgeCollider2D edgeCollider;
    
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            GameObject drawing = Instantiate(drawingPrefab);
            lineRenderer = drawing.GetComponent<LineRenderer>();
            edgeCollider = drawing.GetComponent<EdgeCollider2D>();
            lineRenderer.positionCount = 2;            
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.startColor = colors[K];
            lineRenderer.endColor = colors[K];
        }

        if (Input.GetMouseButton(1))
        {
            FreeDraw();
        }

        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            K++;

            if (K > 3)
            {
                K = 0;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            K--;

            if (K < 0)
            {
                K = 3;
            }
        }

        colorIndicator.color = colors[K];
    }

    void FreeDraw()
    {
        Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, new Vector3(startPosition.x, startPosition.y, 0f));
        lineRenderer.SetPosition(1, new Vector3(Position.x, Position.y, 0f));
        SetEdges(lineRenderer);
        
    }

    void SetEdges(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();

        for (int point = 0; point < lineRenderer.positionCount; point++)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }

        edgeCollider.SetPoints(edges); 
        
    }

    
}
