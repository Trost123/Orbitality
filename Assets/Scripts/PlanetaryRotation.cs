using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryRotation : MonoBehaviour
{
    [Tooltip("Degrees per second.")]
    public float rotationSpeed;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
