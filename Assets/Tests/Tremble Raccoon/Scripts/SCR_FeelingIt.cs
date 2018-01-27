﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SCR_FeelingIt : MonoBehaviour {

    public Rigidbody chest;
    [HideInInspector]
    public Transform boredPosition;
    [HideInInspector]
    public Transform dancingPosition;
    [HideInInspector]
    public float myChanceToShine;

    private NavMeshAgent navMesh;
    private Slider danceMeter;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        danceMeter = FindObjectOfType<Slider>();
        StartCoroutine(Rythm());
        transform.LookAt(GameObject.Find("K-Lmao").transform);
    }

    private void Update()
    {
        if (danceMeter.value >= myChanceToShine)
        {
            navMesh.SetDestination(dancingPosition.position);
            transform.LookAt(GameObject.Find("K-Lmao").transform);
        }
        else
            navMesh.SetDestination(boredPosition.position);
    }

    IEnumerator Rythm()
    {
        yield return new WaitForSeconds(0.5f);
        chest.AddForce(Vector3.up * 1000);
        StartCoroutine(Rythm());
    }
}