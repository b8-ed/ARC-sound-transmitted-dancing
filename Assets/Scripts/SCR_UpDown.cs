using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_UpDown : MonoBehaviour {

    bool canRotate = false;
    bool goingback = false;

    float timer = 0.5f;

    private void Start()
    {
        canRotate = true;
    }

    private void Update()
    {
        if (canRotate)
        {
            if (!goingback)
                transform.Translate(Vector3.up * Time.deltaTime * 0.5f);
            else
                transform.Translate(-Vector3.up * Time.deltaTime * 0.5f);

            timer -= Time.deltaTime;

            if (timer < 0.0f && !goingback)
            {
                goingback = true;
                timer = 0.5f;
            }

            else if (timer < 0.0f && goingback)
            {
                goingback = false;
                timer = 0.5f;
            }
        }
    }
}
