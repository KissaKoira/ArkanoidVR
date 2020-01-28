using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcefield : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            this.GetComponent<Animator>().SetTrigger("hit");
        }
    }
}
