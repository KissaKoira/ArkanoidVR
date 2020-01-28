using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testControls : MonoBehaviour
{
    float rotateSpeed = 100;
    float moveSpeed = 5;

    void Update()
    {
        //racket movement

        transform.position += new Vector3(Input.GetAxis("Mouse X") * 0.5f, Input.GetAxis("Mouse Y") * 0.5f, 0);

        if (Input.GetButton("Jump"))
        {
            //up
            transform.Rotate(new Vector3(rotateSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetButton("Crouch"))
        {
            //down
            transform.Rotate(new Vector3(rotateSpeed * -1 * Time.deltaTime, 0, 0));
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //right
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            //left
            transform.Rotate(new Vector3(0, rotateSpeed * -1 * Time.deltaTime, 0));
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            //forward
            this.GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            //backward
            this.GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed * -1;
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();

            ballRB.velocity = Vector3.Reflect(ballRB.velocity, transform.forward) + this.GetComponent<Rigidbody>().velocity;
        }
    }
}
