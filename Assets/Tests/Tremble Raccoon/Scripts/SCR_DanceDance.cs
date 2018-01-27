using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SCR_DanceDance : MonoBehaviour {

    public Rigidbody[] bone;

    private float danceForce = 500;
    private Slider danceMeter;
    private SCR_GameManager gameManager;
    private float idleTimer = 0.5f;
    private enum DanceDirection
    {
        UP,
        FORWARD,
        BACKWARD
    }

    private void Start()
    {
        danceMeter = FindObjectOfType<Slider>();
        gameManager = FindObjectOfType<SCR_GameManager>();
        danceMeter.value = 0.2f;
    }

    private void Update()
    {
        if (!SCR_GameManager.start)
            return;
        if(Input.anyKeyDown)
        {
            if (Input.anyKeyDown == Input.GetKeyDown((SCR_GameManager.key + "").ToLower()))
                Dance();
            else
                Miss();
        }
        Idle();
    }

    void Miss()
    {
         danceMeter.value -= 0.01f;
         gameManager.letter.color = Color.red;
    }

    void Idle()
    {
        if (gameManager.letter.color == Color.white || gameManager.letter.color == Color.yellow)
        {
            idleTimer -= Time.deltaTime;
            if (idleTimer < 0)
            {
                gameManager.letter.color = Color.yellow;
                danceMeter.value -= 0.005f;
            }
        }
        else
        {
            idleTimer = 0.5f;
        }
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
        danceMeter.value += 0.005f;
        gameManager.letter.color = Color.green;
    }
}
