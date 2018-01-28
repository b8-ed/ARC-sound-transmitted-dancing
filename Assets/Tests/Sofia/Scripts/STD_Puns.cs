using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STD_Puns : MonoBehaviour {

    public AudioClip audioPun;
    public GameObject uiImage;
    public AudioSource audioSource;

    private void Start()
    {
        uiImage.SetActive(false);
        audioSource.playOnAwake = false;
    }

    public void DisplayPun()
    {
        uiImage.SetActive(true);
        audioSource.clip = audioPun;
        audioSource.Play();
        StartCoroutine(WaitToDismiss());
    }

    IEnumerator WaitToDismiss()
    {
        yield return new WaitForSeconds(1.5f);
        uiImage.SetActive(false);
    }
}
