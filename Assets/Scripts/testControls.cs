using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testControls : MonoBehaviour
{
    float rotateSpeed = 200;
    float moveSpeed = 2;

    public GameObject cam;

    void Update()
    {
        //racket movement
        if (Input.GetButton("Fire2"))
        {
            Quaternion camRot = cam.transform.rotation;
            cam.transform.Rotate(new Vector3(camRot.x, Input.GetAxis("Mouse X"), camRot.z));
        }
        else
        {
            transform.position += new Vector3(Input.GetAxis("Mouse X") * 0.05f, Input.GetAxis("Mouse Y") * 0.05f, 0);
        }
        

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
            Vector3 camForward = cam.transform.forward;

            ballRB.velocity = Vector3.Reflect(ballRB.velocity, transform.forward) + this.GetComponent<Rigidbody>().velocity;
            //ballRB.velocity = camForward * 5;

            //Vector3 point = camForward * 10f;
            //Vector3 point = GameObject.Find("egg").transform.position;

            GameObject[] targets = GameObject.FindGameObjectsWithTag("object");
            float closestDir = 0;
            Vector3 closestPoint = new Vector3();

            for(int i = 0; i < targets.Length; i++)
            {
                Vector3 direction = targets[i].transform.position - collision.gameObject.transform.position;

                float dirDiff = Vector3.Dot(camForward, direction);

                if (i == 0)
                {
                    closestDir = dirDiff;
                    closestPoint = targets[i].transform.position;
                }

                if (dirDiff > closestDir)
                {
                    closestDir = dirDiff;
                    closestPoint = targets[i].transform.position;
                }

                Debug.Log(targets[i].gameObject.name);
            }

            collision.gameObject.GetComponent<ball>().curve(closestPoint);
        }
    }
}
