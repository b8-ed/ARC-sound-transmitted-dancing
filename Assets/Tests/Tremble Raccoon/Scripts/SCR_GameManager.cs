using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_GameManager : MonoBehaviour {

    public static bool start;
    public static char key;

    public Transform gamePosition;
    public Text finalCountDown;
    public Slider danceParty;
    public float keyFrequency = 1.5f;
    public Text letter;
    public Image keyCDSprite;
    public float keyCD = 0;

    private float timer = 3.0f;
    private float turnOffTimer = 4.0f;

    private void Start()
    {
        key = (char)('A' + Random.Range(0, 26));
        danceParty = FindObjectOfType<Slider>();
        timer = 3.0f;
    }

    private void Update()
    {
        KeyCoolDown();

        if (start)
            return;
        timer -= Time.deltaTime;
        turnOffTimer -= Time.deltaTime;

        if (timer > 0)
            finalCountDown.text = ((int)timer + 1).ToString();
        else
            finalCountDown.text = "DANCE";

        transform.position = Vector3.Lerp(transform.position, gamePosition.position, Time.deltaTime * 0.85f);
        transform.rotation = Quaternion.Slerp(transform.rotation, gamePosition.rotation, Time.deltaTime * 0.85f);
        
        if (turnOffTimer < 0)
        {
            //StartCoroutine(ChangeKey());
            finalCountDown.enabled = false;
            start = true;
        }

    }

    IEnumerator ChangeKey()
    {
        yield return new WaitForSeconds(keyFrequency);

        if (danceParty.value < 0.5f)
            keyFrequency = 1.5f;
        if (danceParty.value > 0.5f && danceParty.value < 0.75f)
            keyFrequency = 1.0f;
        else if (danceParty.value > 0.75f)
            keyFrequency = 0.8f;
        keyCD = keyFrequency;
        //letter.color = Color.white;
       // key = (char)('A' + Random.Range(0, 4));
       // letter.text = key + "";
        StartCoroutine(ChangeKey());
    }

    void KeyCoolDown()
    {
        //keyCD -= Time.deltaTime;
        //float newFillAmount = ((keyCD * 100) / keyFrequency) * 0.01f;
        //keyCDSprite.fillAmount = Mathf.Lerp(keyCDSprite.fillAmount, newFillAmount, Time.deltaTime * 100);

        //if (start)
        //    keyCDSprite.enabled = true;
    }
}
