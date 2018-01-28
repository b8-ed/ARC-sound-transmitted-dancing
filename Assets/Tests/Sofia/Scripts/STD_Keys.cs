using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STD_Keys : MonoBehaviour {

    public Text keyDisplay;
    public Slider keyTimeSlider;                     // slider para mostrar el tiempo que tiene el usuario
    private float timeToPressKey = 2.3f;            // el tiempo que tiene el usuario para presionar la tecla. Es el tiempo entre eventos del koreographer
    private float deltaSlider = 0.01f;               //que tan seguido va a actualizarse el slider
    [Tooltip("Todas las teclas posibles a elegir")]
    public KeyCode[] possibleKeys;                  //todas las teclas posibles (de estas se ira escogiendo 1 random)
    private KeyCode currentKey = KeyCode.None;      //la tecla que actualmente se muestra en pantalla
    private List<KeyCode> allSongKeys;              //todas las teclas que se presionaran durante la cancion
    int currentEventIndex = 0;                      //indice del evento actual
    int allSongsCount = 0;
    int currentSampleRate = 0;
    float spawnY;                                   //posicion en la que se va a spawnear el texto siguiente
    int currentEventStart = 0;

    public Text txtPrev0;  //texto para mostrar una tecla despues
    public Text txtPrev1;  // texto para mostrar dos teclas despues

    private bool wasCurrentKeyPressed = false;

    public SCR_DanceDance dance;

    private void Start()
    {
        HideUI();
        if (dance == null)
            dance = FindObjectOfType<SCR_DanceDance>();
    }

    public KeyCode GetCurrentKey()
    {
        return currentKey;
    }

    public void SetAllSongKeys(int eventCount)
    {
        allSongKeys = new List<KeyCode>();
        for(int i = 0; i < eventCount; i++)
        {
            int indexRandKey = Random.Range(0, possibleKeys.Length);
            allSongKeys.Add(possibleKeys[indexRandKey]);
            print(i + " " + possibleKeys[indexRandKey]);
        }
        allSongsCount = eventCount;
    }

    //Genera una tecla a presionar random 
    public void GenerateRandomKey(float currentEventTime, float nextEventTime, int sampleRate, bool isLastEvent = false)
    {
        if(possibleKeys != null)
        {            
            currentKey = allSongKeys[currentEventIndex];
            keyDisplay.text = currentKey.ToString();
            wasCurrentKeyPressed = false;
            SetTime(currentEventTime, nextEventTime, sampleRate, isLastEvent);   // set max time and slider values
            keyTimeSlider.gameObject.SetActive(true);   //make sure we're displaying slider
            StartCoroutine(UpdateSlider());            //start the countdown with the slider
            currentEventStart = (int)currentEventTime;
            //mostrar las teclas que van despues
            if (currentEventIndex + 1 < allSongsCount)
            {
                txtPrev0.text = allSongKeys[currentEventIndex + 1].ToString();
            }
            else
                txtPrev0.text = "";
            if (currentEventIndex + 2 < allSongsCount)
                txtPrev1.text = allSongKeys[currentEventIndex + 2].ToString();
            else
                txtPrev1.text = "";
            currentEventIndex++;        //aumentar el index para el siguiente evento
        }
    }

    //Funcion que calcula el tiempo hata el siguiente evento
    //y asigna los valores al slider
    private void SetTime(float currentEventTime, float nextEventTime, int sampleRate, bool isLastEvent)
    {
        Debug.Log("TIME: " + (nextEventTime - currentEventTime) + " Sample Rate: " + sampleRate);
        if (!isLastEvent)
            timeToPressKey = ((nextEventTime - currentEventTime)) / 100000;     //formula para sacar el tiempo a partir de sample location
        else
            timeToPressKey = 1.5f;
        keyTimeSlider.maxValue = timeToPressKey;
        keyTimeSlider.value = timeToPressKey;
        currentSampleRate = sampleRate;
    }
    
    IEnumerator UpdateSlider()
    {
        yield return new WaitForSeconds(deltaSlider);
        keyTimeSlider.value -= deltaSlider;
        if (keyTimeSlider.value > 0 && !wasCurrentKeyPressed) // si ya se presiono la tecla, no sirve seguir actualizando el slider
            StartCoroutine(UpdateSlider());
        else if(keyTimeSlider.value <= 0)//if the value reached 0
        {
            //if the key was never pressed
            if(!wasCurrentKeyPressed)
            {
                //loose points / punish user or something of the sort
                dance.Miss();
            }
            HideUI();
        }
    }

    
    //Oculta el slider en el que se muestra al usuario el tiempo que tiene para presionar tecla
    //y el texto del input lo pone vacio
    void HideUI()
    {
        keyTimeSlider.gameObject.SetActive(false);
        keyDisplay.text = "";
    }
    //Muestra el slider en el que se muestra al usuario el tiempo que tiene para presionar tecla
    void ShowUI()
    {
        keyTimeSlider.gameObject.SetActive(true);
    }

    private void Update()
    {
        //Check if current key is pressed
        if(Input.GetKeyDown(currentKey) && currentKey != KeyCode.None)
        {
            wasCurrentKeyPressed = true;
            currentKey = KeyCode.None;
            dance.Dance(); //Aumentar su valor de baile / aka win
            HideUI(); //hide slider
            Debug.Log("current key pressed!" + currentKey);
        }
    }

}
