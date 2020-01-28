using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCylinder : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Rigidbody>().angularVelocity = this.GetComponent<Rigidbody>().transform.up * 0.5f;
    }
}
