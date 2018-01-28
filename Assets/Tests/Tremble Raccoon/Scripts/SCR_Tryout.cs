using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Tryout : MonoBehaviour {
    public Rigidbody[] bone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            int randomNum = Random.Range(0, bone.Length);
            bone[randomNum].AddForce((Vector3.forward + Vector3.up) * 50);
        }
	}
}
