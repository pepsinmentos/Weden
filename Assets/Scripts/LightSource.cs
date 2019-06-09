using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attributes;

public class LightSource : MonoBehaviour
{
    public string Name;
    public float GrowthRate;
    public float MoistureRetention;
    private List<PlantGeneric> plants;

    public void OnLightStart()
    {
        plants = new List<PlantGeneric>(Object.FindObjectsOfType<PlantGeneric>());
        Light(plants);
        Debug.Log("Light has started");
    }

    public void Light(List<PlantGeneric> plants)
    {
        foreach (var plant in plants)
        {
            plant.Photosynthesis.AddModifier(new AttributeModifier(GrowthRate, AttributeModType.Percent, this));
            plant.Moisture.AddModifier(new AttributeModifier(MoistureRetention, AttributeModType.Flat, this));
            Debug.Log("all plants are lit");
        }
    }

    public void Dark(PlantGeneric plants)
    {
        plants.Photosynthesis.RemoveAllModifiersFromSource(this);
        plants.Moisture.RemoveAllModifiersFromSource(this);
    }
}
