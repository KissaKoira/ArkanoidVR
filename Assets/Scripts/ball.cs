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

        //test
        rb.velocity = new Vector3(0, 0, -50);
    }

    float maxVelocity = 50;

    //test - def arvo 15
    float gravity = 0;

    private void Update()
    {
        if(rb.velocity.z < maxVelocity)
        {
            rb.velocity -= Vector3.Normalize(this.transform.position - player.transform.position) * gravity * Time.deltaTime;
        }

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity), Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity), Mathf.Clamp(rb.velocity.z, -maxVelocity, maxVelocity));
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
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "surface_sphere_inverted")
        {
            Vector3 normal = Vector3.Normalize(this.transform.position - collision.transform.position);

            rb.velocity = Vector3.Reflect(rb.velocity, normal) * bounciness;

            ballPoint = this.transform.position;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(ballPoint, 1);
    }
}
