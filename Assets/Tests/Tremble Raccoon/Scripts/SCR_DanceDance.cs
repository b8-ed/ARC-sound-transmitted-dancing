using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SCR_DanceDance : MonoBehaviour {

    public Rigidbody[] bone;

    private float danceForce = 50;
    public Slider danceMeter;
    private SCR_GameManager gameManager;
    private float idleTimer = 0.5f;
    private STD_Keys keysManager;//para seguir los inputs del koreographer
    private float danceVal = 0.05f; //el valor que se suma / resta al slider en caso de atinar/fallar la tecla
    private int direction = 1;
    private float danceMeterValue;

    public STD_Puns[] puns;

    private enum DanceDirection
    {
        UP,
        FORWARD,
        BACKWARD
    }

    private void Start()
    {
        if(danceMeter == null)
        danceMeter = FindObjectOfType<Slider>();
        gameManager = FindObjectOfType<SCR_GameManager>();
        keysManager = FindObjectOfType<STD_Keys>(); 
        danceMeterValue = 0.2f;
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
    private void Update()
    {
        danceMeterValue = Mathf.Clamp01(danceMeterValue);
        danceMeter.value = Mathf.Lerp(danceMeter.value, danceMeterValue, Time.deltaTime);
    }
    public void Miss()
    {
         danceMeterValue -= (danceVal / 2);
        if (danceMeterValue <= 0)
            StartCoroutine(WaitToLoose());
         //gameManager.letter.color = Color.red;
    }

    IEnumerator WaitToLoose()
    {
        yield return new WaitForSeconds(3);
        if(danceMeterValue <= 0)
        {
            //loose
            GameOver();
        }
    }

    public void GameOver(bool didPlayerWin = false)
    {
        STD_GameOver.lastSceneName = SceneManager.GetActiveScene().name;
        STD_GameOver.youWin = didPlayerWin;
        SceneManager.LoadScene("Game Over");
    }

    void Idle()
    {
            idleTimer -= Time.deltaTime;
            if (idleTimer < 0)
            {
                gameManager.letter.color = Color.yellow;
                danceMeterValue -= 0.001f;
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

        danceMeterValue += danceVal;

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
        danceMeterValue += danceVal;

        direction *= -1;
        int randomNum = Random.Range(0, bone.Length);
        for (int i = 0; i < 4; i++)
        {
            if (randomNum + i < bone.Length)
                bone[randomNum + i].AddForce(((direction * Vector3.right) + mayTheForceBeWithYou) * danceForce);
        }
    }
}
