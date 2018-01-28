using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_ControlsSlider : MonoBehaviour {

    public Sprite[] controlsImg;

    private int index = 0;
    private Image IMG_Control;

	// Use this for initialization
	void Start ()
    {
        IMG_Control = GetComponent<Image>();
	}

    private void OnEnable()
    {
        StartCoroutine(StartSlider());

    }

    IEnumerator StartSlider()
    {
        yield return new WaitForSeconds(0.5f);
        index++;

        if(index > controlsImg.Length - 1)
        {
            index = 0;
        }

        IMG_Control.sprite = controlsImg[index];

        StartCoroutine(StartSlider());
    }
}
