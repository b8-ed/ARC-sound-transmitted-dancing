using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SCR_DanceDance : MonoBehaviour {

    public Rigidbody[] bone;

    private float danceForce = 600;
    private Slider danceMeter;
    private SCR_GameManager gameManager;
    private float idleTimer = 0.5f;
    private STD_Keys keysManager;//para seguir los inputs del koreographer
    private float danceVal = 0.1f; //el valor que se suma / resta al slider en caso de atinar/fallar la tecla

    public STD_Puns[] puns;

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
        keysManager = FindObjectOfType<STD_Keys>(); 
        danceMeter.value = 0.2f;
    }
    
    //Esto ahora se hace desde STD Keys al recibir los eventos
    //private void Update()
    //{
    //    if (!SCR_GameManager.start)
    //        return;
    //    //esto se va a hacer desde std_keys
    //    //if (Input.anyKeyDown)
    //    //{
    //    //    if (Input.anyKeyDown == Input.GetKeyDown(keysManager.GetCurrentKey()) && keysManager.GetCurrentKey() != KeyCode.None)
    //    //        Dance();
    //    //    else
    //    //        Miss();
    //    //}
    //    //Idle();
    //}

    public void Miss()
    {
         danceMeter.value -= danceVal;
         //gameManager.letter.color = Color.red;
    }

    void Idle()
    {
            idleTimer -= Time.deltaTime;
            if (idleTimer < 0)
            {
                gameManager.letter.color = Color.yellow;
                danceMeter.value -= 0.001f;
            }
    }

    public void Dance()
    {
        //mostrar random pun
        int randPun = Random.Range(0, puns.Length + 5);
        if(randPun < puns.Length)
        {
            puns[randPun].DisplayPun();
        }

        //Reset Idle Timer
        idleTimer = 0.5f;
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
        if(bone.Length > 0)
            bone[rand].AddForce(mayTheForceBeWithYou * danceForce);
        danceMeter.value += danceVal;       
    }
}
