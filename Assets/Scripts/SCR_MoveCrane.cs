using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MoveCrane : MonoBehaviour {

    bool canRotate = false;
    bool goingback = false;

    float timer = 0.5f;

	public void RotateCrane()
    {
        canRotate = true;
    }

    private void Update()
    {
        if(canRotate)
        {
            if(!goingback)
                transform.Rotate(Vector3.forward * Time.deltaTime * 10.0f);
            else
                transform.Rotate(-Vector3.forward * Time.deltaTime * 10.0f);

            timer -= Time.deltaTime;

            if(timer < 0.0f && !goingback)
            {
                goingback = true;
                timer = 0.5f;
            }

            else if (timer < 0.0f && goingback)
            {
                goingback = false;
                timer = 0.5f;
                canRotate = false;
            }
        }
    }
}
