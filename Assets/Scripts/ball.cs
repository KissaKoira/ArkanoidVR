using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -30);
    }

    Vector3 ballPoint;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "surface_flat")
        {
            rb.velocity = Vector3.Reflect(rb.velocity, collision.transform.forward);
        }
        else if(collision.gameObject.tag == "surface_cylinder")
        {
            Vector3 normal = Vector3.Normalize(this.transform.position - collision.transform.position);
            Vector3 reflected = Vector3.Reflect(rb.velocity, normal);

            rb.velocity = new Vector3(reflected.x, rb.velocity.y, reflected.z);

            ballPoint = this.transform.position;
        }
        else if (collision.gameObject.tag == "surface_sphere")
        {
            Vector3 normal = Vector3.Normalize(this.transform.position - collision.transform.position);

            rb.velocity = Vector3.Reflect(rb.velocity, normal);

            ballPoint = this.transform.position;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(ballPoint, 1);
    }
}
