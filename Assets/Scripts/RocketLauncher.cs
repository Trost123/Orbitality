using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocket;

    public ProgressBar reloadIndicator;

    public float reloadTime = 30;

    private float _currentReload;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootRocket();
        }

        if (_currentReload > 0)
        {
            _currentReload -= Time.deltaTime;
        }
        reloadIndicator.FillPercentage = (1 - (_currentReload / reloadTime)) * 100f;
    }

    void ShootRocket()
    {
        if (_currentReload <= 0)
        {
            Instantiate(rocket, transform.position, transform.rotation);
            _currentReload = reloadTime;
        }
    }
}
