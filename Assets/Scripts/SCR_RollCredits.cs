using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_RollCredits : MonoBehaviour {

    public TextMeshProUGUI[] creditsTXT;
    private int index = 0;

	// Use this for initialization
	void OnEnable ()
    {
        index = 0;

        for(int i = 0; i < creditsTXT.Length; i++)
        {
            creditsTXT[i].gameObject.SetActive(false);
        }

        StartCoroutine(RollCredits());
	}
	
	IEnumerator RollCredits()
    {
        creditsTXT[index].gameObject.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        if(index < creditsTXT.Length - 1)
        {
            creditsTXT[index].gameObject.SetActive(false);
            index++;
            StartCoroutine(RollCredits());
        }

        else
        {
            FindObjectOfType<SCR_MainMenuManager>().OnBackClicked();
        }
    }
}
