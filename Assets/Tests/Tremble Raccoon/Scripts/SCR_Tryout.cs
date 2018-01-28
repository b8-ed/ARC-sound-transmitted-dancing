using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Tryout : MonoBehaviour {
    public Rigidbody[] bone;
    private int direction = 1;
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            direction *= -1;
            int randomNum = Random.Range(0, bone.Length);
            for (int i = 0; i < 4; i++)
            {
                if (randomNum + i < bone.Length)
                    bone[randomNum + i].AddForce(((direction * Vector3.right) + Vector3.up) * 50);
            }
        }
	}
}
