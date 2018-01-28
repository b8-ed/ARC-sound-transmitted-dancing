using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class STD_KEventSubscriber : MonoBehaviour {

    //public Renderer cubeMat;
    public STD_Keys keyManager;

    private Koreography koreography; // the koreography to read tracks from
    private string keyEventID = "STD_Track_Keys";
    List<KoreographyEvent> keyEvents; // list of all events within the track for keys
    int keyEventsLength; //el tamanio de la lista para no tener que estarla cargando
    float leadInTimeLeft;

    //enum to know what koreographe int payloads mean
    enum KoreoInts
    {
        _1_GenerateRandomKey = 1,
    }

    private void Start()
    {
        //Para regirstar respuestas a eventos del koreographer
        //Koreographer.Instance.RegisterForEvents("STD_Track_A", ChangeLightColor);
        Koreographer.Instance.RegisterForEvents(keyEventID, GenerateKey);

        //get the current koreographer
        koreography = Koreographer.Instance.GetKoreographyAtIndex(0);

        //Get all events out of the track
        KoreographyTrackBase keyTrack = koreography.GetTrackByID(keyEventID);
        keyEvents = keyTrack.GetAllEvents();
        keyEventsLength = keyEvents.Count;
        keyManager.SetAllSongKeys(keyEventsLength);
    }

    //Cambia el color de un material
    public void ChangeLightColor(KoreographyEvent koreoEvent)
    {
        //if(koreoEvent.HasColorPayload())
        //{
        //    cubeMat.material.color = koreoEvent.GetColorValue();
        //}
    }

    public void GenerateKey(KoreographyEvent koreographyEvent)
    {
        if(koreographyEvent.HasIntPayload())
        {
            if(koreographyEvent.GetIntValue() == (int)KoreoInts._1_GenerateRandomKey)
            {
                if (keyEvents.Contains(koreographyEvent))
                {
                    Debug.Log("Se encontro!");
                    for (int i = 0; i < keyEventsLength; i++)
                    {
                        //si empiezan en el mismo tiempo es que son el mismo
                        if(keyEvents[i].StartSample == koreographyEvent.StartSample)
                        {
                            if(i+ 1 < keyEventsLength)
                                keyManager.GenerateRandomKey(koreographyEvent.EndSample, keyEvents[i+1].StartSample, koreography.SampleRate);
                            else
                                keyManager.GenerateRandomKey(koreographyEvent.EndSample, 0, koreography.SampleRate, true);
                            break;
                        }
                    }
                }
                else
                    Debug.Log("No se encontro ):");

            }
            Debug.Log(koreographyEvent.GetIntValue());
        }
    }

}
