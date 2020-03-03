using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OrbitMotion))]
public class OrbitLineCreator : MonoBehaviour
{
    public GameObject TrajectoryGameObject;
    private EllipseRenderer _ellipse;
    private OrbitMotion _orbitMotion;
    private Transform _trajectoriesContainer;
    // Start is called before the first frame update
    void Start()
    {
        _orbitMotion = GetComponent<OrbitMotion>();
        _trajectoriesContainer = transform.parent.Find("Trajectories");
        _ellipse = Instantiate(TrajectoryGameObject, _trajectoriesContainer).GetComponent<EllipseRenderer>();
        _ellipse.ellipse = _orbitMotion.orbitPath;
        _ellipse.CalculateEllipse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
