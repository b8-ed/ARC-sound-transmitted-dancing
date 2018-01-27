using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class STD_KEventSubscriber : MonoBehaviour {

    public Light colorLight;

    private void Start()
    {
        Koreographer.Instance.RegisterForEvents("STD_Track_A", ChangeLightColor);
    }

    public void ChangeLightColor(KoreographyEvent koreoEvent)
    {
        if(koreoEvent.HasColorPayload())
        {
            colorLight.color = koreoEvent.GetColorValue();
        }
        else if(koreoEvent.HasTextPayload())
        {

        }
    }
}
