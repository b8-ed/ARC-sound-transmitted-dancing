using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_DanceDance : MonoBehaviour {

    public Rigidbody[] bone;
    public float danceForce = 300;

    private enum DanceDirection
    {
        UP,
        FORWARD,
        BACKWARD
    }

    private void Update()
    {
        //lol
        //Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.V)
        if (Input.GetKey(KeyCode.Space))
            Dance();
    }

    public void Dance()
    {
        //Get a random bone
        int rand = Random.Range(0, bone.Length);
        //Get a random force direction
        int randDirection = Random.Range(0, 3);
        Vector3 mayTheForceBeWithYou;
        //Set the force direction
        if (randDirection == (int)DanceDirection.UP)
            mayTheForceBeWithYou = Vector3.up;
        else if (randDirection == (int)DanceDirection.FORWARD)
            mayTheForceBeWithYou = Vector3.forward;
        else
            mayTheForceBeWithYou = -Vector3.forward;
        //Move it move it
        bone[rand].AddForce(mayTheForceBeWithYou * danceForce);
    }
}
