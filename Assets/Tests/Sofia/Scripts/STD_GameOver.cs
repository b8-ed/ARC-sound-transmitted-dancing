using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STD_GameOver : MonoBehaviour {

	public static string lastSceneName = "";
    public static bool youWin = false;
    public AudioClip AC_Boo;
    public AudioClip AC_Yeh;

    public GameObject panelWin;

    private AudioSource auSrc;

    private void Start()
    {
        auSrc = GetComponent<AudioSource>();
        if(youWin)
        {
            auSrc.clip = AC_Yeh;
        }

        else
        {
            auSrc.clip = AC_Boo;
        }

        auSrc.Play();

        panelWin.SetActive(youWin);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        lastSceneName = "";
    }

    public void Retry()
    {
        if(!string.IsNullOrEmpty(lastSceneName))
        {
            SceneManager.LoadScene(lastSceneName);
        }
            
    }
    

}
