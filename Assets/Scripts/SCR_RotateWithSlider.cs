using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_RotateWithSlider : MonoBehaviour {

    public Slider SLD_Disk;

	void Update ()
    {
        transform.Rotate(Vector3.forward * SLD_Disk.value * 10);
	}
}
