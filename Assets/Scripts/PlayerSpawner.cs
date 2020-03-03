using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public int playerCount = 4;
    public int myPlayerIndex = 1;
    public Transform solarSystemTransform;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    private Vector2 _lastOrbitSize = new Vector2(1f,1f);
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject anPlayer;
            if (i == myPlayerIndex)
            {
                anPlayer = Instantiate(playerPrefab, solarSystemTransform);
                GameObject.FindWithTag("MainCamera").GetComponent<DampCamera2D>().target = anPlayer.transform;
            }
            else
            {
                anPlayer = Instantiate(enemyPrefab, solarSystemTransform);
            }
            anPlayer.transform.Find("Planet").Rotate(0, Random.Range(0, 350f), 0);

            OrbitMotion playerOrbitMotion = anPlayer.GetComponent<OrbitMotion>();
            playerOrbitMotion.orbitPath.xAxis = _lastOrbitSize.x += Random.Range(0.4f, 1f); //I hope this works ;)
            playerOrbitMotion.orbitPath.yAxis = _lastOrbitSize.y += Random.Range(0.4f, 1f);
            playerOrbitMotion.orbitProgress = Random.Range(0f, 1f);
            playerOrbitMotion.orbitPeriod = Random.Range(15f, 40f);

            playerOrbitMotion.enabled = true; // Runtime enabiling is a workaround for planet mesh being created in WORLD space 0,0,0. Fix this later!
        }
    }
}
