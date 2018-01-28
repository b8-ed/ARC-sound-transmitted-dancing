using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STD_Lights : MonoBehaviour {

    public Light[] lightsToChangeColor;

    public void ChangeLightColors()
    {
        Color _color = Random.ColorHSV(0.10f, 1, 0.85f, 1.5f, 0.23f, 1.0f);
        foreach (Light light in lightsToChangeColor)
        {
            light.color = _color;
        }
    }
}
