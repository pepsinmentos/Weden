using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attributes;

public class PlantGeneric : MonoBehaviour
{
    public bool isNew = true;

    [Header("Attributes")]

    public Attribute Photosynthesis;
    public Attribute Moisture;
    public Attribute Nutrition;

    //[Header("Modifiers")]
    //public string GrowthRate;
    //public string MoistureRetention;
    //public string SoilQuality;

    public void OnNewDay()
    {
        //update stats based on modifier rates
        Photosynthesis.updateBaseValue();
        Moisture.updateBaseValue();
        Debug.Log("Plants have updated base value");
    }

    //public PlantAttribute Soil_pH;
    //public PlantAttribute SoilType;
}
