using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EllipseRenderer : MonoBehaviour
{
    LineRenderer lr;

    [Range (3,36)]
    public int segments;

    public Ellipse ellipse;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        CalculateEllipse();
    }

    public void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments];
        for (int i = 0; i < segments; i++)
        {
            Vector2 position2D = ellipse.Evaluate(t: (float) i / segments);
            points[i] = new Vector3(position2D.x, position2D.y, 0f);
        }

        lr.positionCount = segments;
        lr.SetPositions(points);
    }

    private void OnValidate()
    {
        if (Application.isPlaying && lr)
        {
            CalculateEllipse();
        }
    }
}
