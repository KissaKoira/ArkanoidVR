using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testControls : MonoBehaviour
{
    float rotateSpeed = 100;
    float moveSpeed = 20;

    public GameObject cam;

    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 camForward = cam.transform.forward;

            //hyvä versio vois näyttää kutakuinkun tältä: (mutta reflect bugaa)
            //ballRB.velocity = Vector3.Reflect(ballRB.velocity, transform.forward).normalized * this.GetComponent<Rigidbody>().velocity.magnitude;

            //tää on vaan testiä varten nyt:
            ballRB.velocity = this.GetComponent<Rigidbody>().velocity * 3;

            GameObject[] targets = GameObject.FindGameObjectsWithTag("object");
            float closestDir = 0;
            Vector3 closestPoint = new Vector3();

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
                    }

                    if (dirDiff > closestDir)
                    {
                        closestDir = dirDiff;
                        closestPoint = targets[i].transform.position;
                    }

                    Debug.Log(targets[i].gameObject.name);
                }
            }

            collision.gameObject.GetComponent<ball>().curve(closestPoint);
        }
    }
}
