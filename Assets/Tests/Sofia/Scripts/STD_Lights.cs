using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STD_Lights : MonoBehaviour {

    public Light[] lightsToChangeColor;
    public Color[] possibleColors;

    public void ChangeLightColors()
    {
        foreach (Light light in lightsToChangeColor)
        {
            if(possibleColors.Length > 0)
            {
                int randIndex = Random.Range(0, possibleColors.Length);
                light.color = possibleColors[randIndex];
            }
            else
            {
                light.color = Random.ColorHSV(0.10f, 1, 0.85f, 1.5f, 0.23f, 1.0f);
            }
        }
            
    }
}
