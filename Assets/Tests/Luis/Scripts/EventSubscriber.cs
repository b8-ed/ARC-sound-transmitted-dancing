using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SonicBloom.Koreo;

public class EventSubscriber : MonoBehaviour {

    [EventID]
    public string eventID;
	// Use this for initialization
	void Start () {
        Koreographer.Instance.RegisterForEventsWithTime("STD_Track_A", FireEventDebugLog);
	}

    void OnDestroy()
    {
        // Sometimes the Koreographer Instance gets cleaned up before hand.
        //  No need to worry in that case.
        if (Koreographer.Instance != null)
        {
            Koreographer.Instance.UnregisterForAllEvents(this);
        }
    }

    private void Update()
    {
        
    }

    void FireEventDebugLog(KoreographyEvent koreoEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        Debug.Log("Koreography Event Fired");

        Debug.Log("Sample Time: " + sampleTime + "\nSample delta: " + sampleDelta + "\nPrevious Frame: " + (sampleTime - sampleDelta));
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("FUCK THIS");
            GameObject.Find("Text").GetComponent<Text>().text = "JA THIS MOFO";
        }

        if (koreoEvent.IsOneOff() && koreoEvent.HasColorPayload())
        {
            // This is a simple Color Payload.
            Color targetColor = koreoEvent.GetColorValue();
            ApplyColorToObjects(ref targetColor);
        }
        else if (!koreoEvent.IsOneOff() && koreoEvent.HasGradientPayload())
        {
            // Access the color specified at the current music-time.  This is what
            //  drives musical color animations from gradients!
            Color targetColor = koreoEvent.GetColorOfGradientAtTime(sampleTime);
            ApplyColorToObjects(ref targetColor);
        }

        Color targetColor1 = koreoEvent.GetColorValue();
        ApplyColorToObjects(ref targetColor1);
    }

    public void ApplyColorToObjects(ref Color targetColor)
    {
        GameObject.Find("Cube").GetComponent<MeshRenderer>().materials[0].color = targetColor;
    }

}
