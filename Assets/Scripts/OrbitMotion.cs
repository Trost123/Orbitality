using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    public Ellipse orbitPath;
    
    [Range(0f,1f)]
    public float orbitProgress = 0f;
    public float orbitPeriod = 3f;
    public bool orbitActive = true;
    // Start is called before the first frame update
    void Start()
    {
        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    }

    void SetOrbitingObjectPosition()
    {
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        transform.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }

    IEnumerator AnimateOrbit()
    {
        float orbitSpeed = 1f / Mathf.Max(orbitPeriod, 0.1f);
        while (orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f; //same as Mathf.Clamp01(orbitProgress);
            SetOrbitingObjectPosition();
            yield return null;
        }
    }
}
