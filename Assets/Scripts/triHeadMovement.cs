﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triHeadMovement : MonoBehaviour
{
    //how fast NPC moves
    public float walkSpeed;
    //contains all points where NPC can go
    public Transform[] moveToPoint;


    private int randomPoint;
    public float whenNear;
    private float waitTime;
    public float startWaitTime;
    public float rotationSpeed;
    private Quaternion lookRotation;
    private Vector3 lookDirection;

    void Start()
    {
        waitTime = startWaitTime;
        randomPoint = Random.Range(0, moveToPoint.Length);
    }

    void Update()
    {
        lookDirection = (moveToPoint[randomPoint].position - transform.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position, moveToPoint[randomPoint].position, walkSpeed * Time.deltaTime);

        lookRotation = Quaternion.LookRotation(lookDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        if (Vector3.Distance(transform.position, moveToPoint[randomPoint].position) < whenNear && waitTime <= 0)
        {
            randomPoint = Random.Range(0, moveToPoint.Length);
            waitTime = startWaitTime;
        } else {
            waitTime -= Time.deltaTime;
        }
    }
}
