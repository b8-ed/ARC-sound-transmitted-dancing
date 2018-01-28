using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STD_GameOver : MonoBehaviour {

	public static string lastSceneName = "";
    public static bool youWin = false;

    public GameObject panelWin;

    private void Start()
    {
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
