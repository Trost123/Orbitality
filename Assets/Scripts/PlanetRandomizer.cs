using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetRandomizer : MonoBehaviour
{
    public Planet planet;
    public ColourSettings[] colorSettingsPool;
    public ShapeSettings[] shapeSettingsPool;
    private static int _shapePoolID;
    private List<GradientColorKey[]> colorKeysBackup;

    // Start is called before the first frame update
    void Start()
    {
        if (planet)
        {
            if (colorSettingsPool.Length != shapeSettingsPool.Length)
            {
                Debug.LogError("Color and shape pools should be the same size!");
                return;
            }
            planet.colourSettings = colorSettingsPool[_shapePoolID];
            planet.shapeSettings = shapeSettingsPool[_shapePoolID];
            _shapePoolID++;
            if (_shapePoolID >= colorSettingsPool.Length)
            {
                _shapePoolID = 0;
            }
            
            NoiseSettings.SimpleNoiseSettings layer1 = planet.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings;
            layer1.strength = Random.Range(0.06f, 0.2f);
            layer1.numLayers = Random.Range(1, 5);
            layer1.baseRoughness = Random.Range(0.1f, 4f);
            layer1.roughness = Random.Range(1f, 3f);
            layer1.minValue = Random.Range(0.5f, 2.5f);
            layer1.centre = new Vector3(Random.Range(1,10),Random.Range(1,10),Random.Range(1,10));
            
            NoiseSettings.RidgidNoiseSettings layer2 = planet.shapeSettings.noiseLayers[1].noiseSettings.ridgidNoiseSettings;
            layer2.strength = Random.Range(0.6f, 1.6f);
            layer2.numLayers = Random.Range(1, 5);
            layer2.baseRoughness = Random.Range(0.1f, 4f);
            layer2.roughness = Random.Range(1f, 3f);
            layer2.minValue = Random.Range(0.5f, 2.5f);
            layer2.weightMultiplier = Random.Range(0.5f, 5f);
            layer2.centre = new Vector3(Random.Range(1,10),Random.Range(1,10),Random.Range(1,10));

            Color randomColor = new Color(
                Random.Range(-0.25f, 0.25f), 
                Random.Range(-0.25f, 0.25f), 
                Random.Range(-0.25f, 0.25f)
            );
            
            colorKeysBackup = new List<GradientColorKey[]>();
            //change sea gradient
            colorKeysBackup.Add(planet.colourSettings.oceanColour.colorKeys);
            GradientColorKey[] colorKeys = planet.colourSettings.oceanColour.colorKeys;
            //planet.colourSettings.oceanColour.SetKeys()
            for (int i = 0; i < colorKeys.Length; i++)
            {
                colorKeys[i].color += randomColor;
            }
            planet.colourSettings.oceanColour.colorKeys = colorKeys;
            
            // change biome gradients
             for (int i = 0; i < 3; i++)
             {
                 colorKeysBackup.Add(planet.colourSettings.biomeColourSettings.biomes[i].gradient.colorKeys);
                 colorKeys = planet.colourSettings.biomeColourSettings.biomes[i].gradient.colorKeys;
                 for (int k = 0; k < colorKeys.Length; k++)
                 {
                     colorKeys[i].color += randomColor;
                 }
                 planet.colourSettings.biomeColourSettings.biomes[i].gradient.colorKeys = colorKeys;
             }
             planet.GeneratePlanet();
        }
    }

    private void OnDisable()
    {
        planet.colourSettings.oceanColour.colorKeys = colorKeysBackup[0];
        for (int i = 1; i < colorKeysBackup.Count; i++)
        {
            planet.colourSettings.biomeColourSettings.biomes[i-1].gradient.colorKeys = colorKeysBackup[i];
        }
        colorKeysBackup = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
