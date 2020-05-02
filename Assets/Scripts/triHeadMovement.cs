using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triHeadMovement : MonoBehaviour
{
    //how fast NPC moves
    public float walkSpeed;
    //contains all points where NPC can go
    public Transform[] moveToPoint;

    public GameObject partEffect;
    private int randomPoint;
    //How near of the moving point trihead guy is allowed to go
    public float whenNear;
    private float waitTime;
    //How long trihead guy will stay on the point
    public float startWaitTime;
    //How fast trihead guy turns to next move point
    public float rotationSpeed;
    private Quaternion lookRotation;
    private Vector3 lookDirection;
    //private float angle;
    //private float radius;

    void Start()
    {
        waitTime = startWaitTime;
        randomPoint = Random.Range(0, moveToPoint.Length);
        //radius = Random.Range(10f, 15f);
        //angle = Random.Range(0f, 360f);
        //double radsToDeg = angle * System.Math.PI / 180f;
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
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Flames();
        }
    }

   public void Flames()
    {
        GameObject flames = Instantiate(partEffect, transform.position, Quaternion.identity);
        partEffect.GetComponent <ParticleSystem>().Play();
    }
}