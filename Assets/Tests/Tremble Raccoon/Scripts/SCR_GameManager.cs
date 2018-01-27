using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_GameManager : MonoBehaviour {

    public static bool start;
    public static char key;

    public Transform gamePosition;
    public Text finalCountDown;

    private float timer = 3.0f;
    private float turnOffTimer = 4.0f;

    private void Update()
    {
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
            StartCoroutine(ChangeKey());
            finalCountDown.enabled = false;
            start = true;
        }
    }

    IEnumerator ChangeKey()
    {
        yield return new WaitForSeconds(1);
        key = (char)('A' + Random.Range(0, 26));
        StartCoroutine(ChangeKey());
    }
}
