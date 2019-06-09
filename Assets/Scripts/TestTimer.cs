using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimer : MonoBehaviour
{
    public bool NewDay;
    private List<LightSource> lightSources;
    private List<PlantGeneric> plantGenerics;

    void Update ()
    {
        if (NewDay)
        {
            lightSources = new List<LightSource>(Object.FindObjectsOfType<LightSource>());
            plantGenerics = new List<PlantGeneric>(Object.FindObjectsOfType<PlantGeneric>());

            foreach (var light in lightSources)
            {
                light.OnLightStart();
            }

            foreach (var plant in plantGenerics)
            {
                plant.OnNewDay();
            }

            NewDay = false;
            Debug.Log("New day updated");
        }
    }
}
