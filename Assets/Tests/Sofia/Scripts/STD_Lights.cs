using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STD_Lights : MonoBehaviour {

    public Light[] lightsToChangeColor;

    public void ChangeLightColors(Color _color)
    {
        foreach(Light light in lightsToChangeColor)
        {
            light.color = _color;
        }
    }
}
