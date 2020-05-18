﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody rb;

    public GameObject spawnPoint;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        spawnPoint = GameObject.Find("BallPoint");
    }

    Vector3 nullPoint = new Vector3(0, 0, 0);
    Vector3 curvePoint = new Vector3(0, 0, 0);

    float maxVelocity = 50;

    private void Update()
    {
        if(curvePoint == nullPoint)
        {
            this.transform.position = spawnPoint.transform.position;
        }

        //clamp to max velocity
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity), Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity), Mathf.Clamp(rb.velocity.z, -maxVelocity, maxVelocity));

        //curve towards a point set on contact with racket
        if (curvePoint != nullPoint)
        {
            Vector3 direction = curvePoint - this.transform.position;
            Vector3 velocity = this.GetComponent<Rigidbody>().velocity;
            float speed = velocity.magnitude * 0.4f * Time.deltaTime;

            Vector3 newVelocity = Vector3.RotateTowards(velocity, direction, speed, 0.0f);
            this.GetComponent<Rigidbody>().velocity = newVelocity;
        }


    }

    float bounciness = 0.8f;
    Vector3 ballPoint;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "surface_flat")
        {
            rb.velocity = Vector3.Reflect(rb.velocity, collision.transform.forward) * bounciness;
        }
        else if (collision.gameObject.tag == "surface_cylinder")
        {
            Vector3 normal = Vector3.Normalize(this.transform.position - collision.transform.position);
            Vector3 reflected = Vector3.Reflect(rb.velocity, normal);

            rb.velocity = new Vector3(reflected.x, rb.velocity.y, reflected.z) * bounciness;

            ballPoint = this.transform.position;
        }
        else if (collision.gameObject.tag == "surface_sphere")
        {
            Vector3 normal = Vector3.Normalize(this.transform.position - collision.transform.position);

            rb.velocity = Vector3.Reflect(rb.velocity, normal) * bounciness;

            ballPoint = this.transform.position;
        }
        else if (collision.gameObject.tag == "object" || collision.transform.parent.gameObject.tag == "object")
        {
            collision.gameObject.SetActive(false);

            if (collision.transform.parent.gameObject.tag == "object")
            {
                collision.transform.parent.gameObject.SetActive(false);
            }

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "surface_reversesphere")
        {
            Vector3 normal = Vector3.Normalize(this.transform.position - collision.transform.position);

            rb.velocity = Vector3.Reflect(rb.velocity, normal) * bounciness;

            ballPoint = this.transform.position;
        }
    }

    public void curve(Vector3 point)
    {
        curvePoint = point;
    }
}
