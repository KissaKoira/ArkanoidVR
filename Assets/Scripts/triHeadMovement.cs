using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triHeadMovement : MonoBehaviour
{
    public float walkSpeed;

    public Transform[] moveToPoint;


    private int randomPoint;
    public float whenNear;
    private float waitTime;
    public float startWaitTime;
    public float rotationSpeed;
    private Quaternion lookRotation;
    private float lookDirection;

    void Start()
    {
        randomPoint = Random.Range(0, moveToPoint.Length);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveToPoint[randomPoint].position, walkSpeed * Time.deltaTime);

        lookDirection = (randomPoint - transform.position).normalized;

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
