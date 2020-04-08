using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public GameObject player;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(0, -10, 0);
    }

    float maxVelocity = 50;
    float gravity = 15f;

    Vector3 nullPoint = new Vector3(0, 0, 0);
    Vector3 curvePoint = new Vector3(0, 0, 0);
    public GameObject ballTarget;

    int goingRight = 0;

    private void Update()
    {
        if (Input.GetButtonDown("test"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 0);
        }

        //gravitate towards a set point in front of player
        if (rb.velocity.z < maxVelocity)// && curvePoint == nullPoint) //otin tän pois testiks
        {
            rb.velocity += Vector3.Normalize(ballTarget.transform.position - this.transform.position) * gravity * Time.deltaTime;
        }

        //hidastetaan pallon liikettä jatkuvasti sen mukaan kuinka lähellä se on pelaajaa. Sillon tulee smoothisti gravitaatiopisteeseen eikä jää
        //kiertämään sitä ympyäri eli korvataan sillä aiempi "ball snap".
        rb.velocity = rb.velocity * (1 - Mathf.Clamp(5.0f - Vector3.Distance(player.transform.position, rb.transform.position), 0.0f, 5.0f) / 250);

        //clamp to max velocity
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity), Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity), Mathf.Clamp(rb.velocity.z, -maxVelocity, maxVelocity));

        /*
        //curve towards a point set on contact with racket
        if(curvePoint != nullPoint)
        {
            Vector3 direction = curvePoint - transform.position;
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            float speed = velocity.magnitude * 0.4f * Time.deltaTime;

            Vector3 newVelocity = Vector3.RotateTowards(velocity, direction, speed, 0.0f);
            GetComponent<Rigidbody>().velocity = newVelocity;
        }
        */
    }

    Vector3 ballPoint;
    float bounciness = 0.8f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "surface_flat")
        {
            rb.velocity = Vector3.Reflect(rb.velocity, collision.transform.forward) * bounciness;
        }
        else if(collision.gameObject.tag == "surface_cylinder")
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
        else if (collision.gameObject.tag == "object")
        {
            Vector3 normal = Vector3.Normalize(this.transform.position - collision.transform.position);
            Vector3 reflected = Vector3.Reflect(rb.velocity, normal);

            rb.velocity = new Vector3(reflected.x, rb.velocity.y, reflected.z) * bounciness;

            ballPoint = this.transform.position;

            if (collision.gameObject.name.Contains("trihead guy"))
            {
                collision.transform.parent.gameObject.SetActive(false);
            }

            collision.gameObject.SetActive(false);
            

            curvePoint = nullPoint;
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

    void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(ballPoint, 1);
    }

    public void curve(Vector3 point)
    {
        curvePoint = point;
    }
}
