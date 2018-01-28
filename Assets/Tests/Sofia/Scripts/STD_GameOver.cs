using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STD_GameOver : MonoBehaviour {

	public static string lastSceneName = "";

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Retry()
    {
        if(!string.IsNullOrEmpty(lastSceneName))
            SceneManager.LoadScene(lastSceneName);
    }
    

}
