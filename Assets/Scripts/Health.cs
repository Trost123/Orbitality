using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    public GameEvent onDeath;
    public float maxHealth = 100;
    public GameObject planetRootObject;
    public GameObject onDeathExplosion;
    [SerializeField] private float currentHealth;
    public float CurrentHealth
    {
        get => currentHealth;
        set
        {
            if (value <= 0)
            {
                value = 0;
                Destroy(planetRootObject);
                Destroy(Instantiate(onDeathExplosion, transform.position, transform.rotation), 2f);
                onDeath.Raise();
            }
            currentHealth = value;
            progressBar.FillPercentage = (currentHealth / maxHealth) * 100f;
        }
    }

    public ProgressBar progressBar;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
    }
}
