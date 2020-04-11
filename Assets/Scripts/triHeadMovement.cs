using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class triHeadMovement : MonoBehaviour
{
    //how fast NPC moves
    public float walkSpeed;
    //contains all points where NPC can go
    public Transform moveToPoint;
    public Transform Xorigin;
    //private float playerposX = player.transform.position.x;


    private int randomPoint;
    public float whenNear;
    private float waitTime;
    public float startWaitTime;
    public float rotationSpeed;
    private Quaternion lookRotation;
    private Vector3 lookDirection;
    private float angle;
    private float radius;
    public float radiusMin;
    public float radiusMax;
    public float angleMin;
    public float angleMax; 
    Vector3 newPos;
    
    

    void Start()
    {
        radius = Random.Range(radiusMin, radiusMax);
        angle = Random.Range(angleMin, angleMax);
        waitTime = startWaitTime;
        Xorigin = Xorigin.transform.position;
        //randomPoint = Random.Range(0, moveToPoint.Length);
        
        double degToRads = angle * System.Math.PI / 180f;
        moveToPoint.position = new Vector3(PointOnCircleX(radius, angle, Xorigin), 0f, PointOnCircleY(radius, angle));
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
            radius = Random.Range(radiusMin, radiusMax);
            angle = Random.Range(angleMin, angleMax);
            moveToPoint.position = new Vector3(PointOnCircleX(radius, angle), 0f, PointOnCircleY(radius, angle));
            waitTime = startWaitTime;
        } else {
            waitTime -= Time.deltaTime;
        }
    }

     private static PointF PointOnCircleX(float r, float rad, System.Drawing.pointF originX)
    {

        // Convert from degrees to radians via multiplication by PI/180        
        float x = (float)(r * System.Math.Cos(rad)) + originX;
        

        return x;

    }

    private static System.Drawing.pointF PointOnCircleY(float r, float rad, System.Drawing.pointF originY)
    {

    float y = (float)(r * System.Math.Sin(rad)) + originY;

    return y;
    }
}
