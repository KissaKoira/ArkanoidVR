using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triHeadMovement : MonoBehaviour
{
    //how fast NPC moves
    public float walkSpeed;
    //contains all points where NPC can go
    public Transform moveToPoint;
    //private float playerposX = player.transform.position.x;


    private int randomPoint;
    public float whenNear;
    private float waitTime;
    public float startWaitTime;
    public float rotationSpeed;
    private Quaternion lookRotation;
    private Vector3 lookDirection;
    public float angle;
    public float radius;
    Vector3 newPos;
    

    void Start()
    {
        waitTime = startWaitTime;
        //randomPoint = Random.Range(0, moveToPoint.Length);
        radius = Random.Range(10f, 15f);
        angle = Random.Range(0f, 360f);
        double degToRads = angle * System.Math.PI / 180f;
        moveToPoint.position = new Vector3(PointOnCircleX(radius, angle), PointOnCircleY(radius, angle), 0f);
    }

    void Update()
    {
        lookDirection = (moveToPoint.position - transform.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position, moveToPoint.position, walkSpeed * Time.deltaTime);

        lookRotation = Quaternion.LookRotation(lookDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        if (Vector3.Distance(transform.position, moveToPoint.position) < whenNear && waitTime <= 0)
        {
            //randomPoint = Random.Range(0, moveToPoint.Length);
            waitTime = startWaitTime;
        } else {
            waitTime -= Time.deltaTime;
        }
    }

     private float PointOnCircleX(float r, float rad)
    {

        // Convert from degrees to radians via multiplication by PI/180        
        float x = (float)(r * System.Math.Cos(rad));
        

        return x;

    }

    private float PointOnCircleY(float r, float rad)
    {

    float y = (float)(r * System.Math.Sin(rad)) + 1f;

    return y;
    }
}
