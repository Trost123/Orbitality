using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Rocket : MonoBehaviour
{
    public float damage;
    public GameObject explosionFx;
    public float speed;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Planet"))
        {
            other.GetComponent<Health>().CurrentHealth -= damage;
        }else if (other.CompareTag("Rocket"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
        Destroy(Instantiate(explosionFx, transform.position, Quaternion.identity), 2f);
    }
}
