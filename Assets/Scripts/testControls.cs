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
        transform.Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

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

        //left - right
        Quaternion camRot = cam.transform.rotation;
        cam.transform.Rotate(new Vector3(camRot.x, Input.GetAxisRaw("Horizontal"), camRot.z));

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

            GameObject[] targets = GameObject.FindGameObjectsWithTag("object");
            float closestDir = 0;
            Vector3 closestPoint = new Vector3();
            string closestObject = "";

            for(int i = 0; i < targets.Length; i++)
            {
                if(targets[i].gameObject.activeSelf == true)
                {
                    Vector3 direction = targets[i].transform.position - collision.gameObject.transform.position;

                    float dirDiff = Vector3.Dot(camForward, direction);

                    if (i == 0)
                    {
                        closestDir = dirDiff;
                        closestPoint = targets[i].transform.position;
                        closestObject = targets[i].gameObject.name;
                    }

                    if (dirDiff > closestDir)
                    {
                        closestDir = dirDiff;
                        closestPoint = targets[i].transform.position;
                        closestObject = targets[i].gameObject.name;
                    }

                    Debug.Log(targets[i].gameObject.name);
                }
            }

            bool looping = true;
            Vector3 directionB = closestPoint - cam.transform.position;
            Vector3 pointB;
            float counter = 100;

            while (looping && counter > 0)
            {
                RaycastHit hit;

                if (Physics.Raycast(cam.transform.position, directionB, out hit, Mathf.Infinity) && hit.collider.gameObject.name == closestObject)
                {
                    closestPoint = hit.point;

                    directionB = Vector3.RotateTowards(directionB, camForward, 1, 0.0f);
                }
                else
                {
                    looping = false;
                }

                counter--;
            }

            collision.gameObject.GetComponent<ball>().curve(closestPoint);
        }
    }
}
