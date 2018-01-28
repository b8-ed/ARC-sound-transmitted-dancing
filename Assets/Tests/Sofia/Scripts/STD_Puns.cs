using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STD_Puns : MonoBehaviour {

    public AudioClip audioPun;
    public GameObject uiImage;
    public AudioSource audioSource;
    private float delay = 1.0f;


    private void Start()
    {
        uiImage.SetActive(false);
        audioSource.playOnAwake = false;
    }

    public void DisplayPun()
    {
        uiImage.SetActive(true);
        if(audioPun != null)
        {
            audioSource.clip = audioPun;
            audioSource.Play();
        }       
        StartCoroutine(WaitToDismiss());
    }

    IEnumerator WaitToDismiss()
    {
        yield return new WaitForSeconds(delay);
        uiImage.SetActive(false);
    }
}
