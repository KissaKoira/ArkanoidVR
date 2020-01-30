using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            GetComponent<Animator>().SetTrigger("hit");
        }

        other.GetComponent<Rigidbody>().velocity *= 1.5f;
    }
}
