using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_RaccoonManager : MonoBehaviour {

    public SCR_FeelingIt[] raccoons;
    private float value;
    private void Awake()
    {
        value = raccoons.Length * raccoons.Length;
        value = raccoons.Length / value;
        for(int i = 0; i < raccoons.Length; i++)
        {
            int raccoonCounter = i + 1;
            raccoons[i].dancingPosition = GameObject.Find("Dancing Raccoon Position (" + raccoonCounter + ")").transform;
            raccoons[i].boredPosition = GameObject.Find("Bored Raccoon Position (" + raccoonCounter + ")").transform;
            raccoons[i].myChanceToShine = (i + 1) * value;
        }
    }
}
