using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDublicate : MonoBehaviour
{

    public GameObject Ball;
    public Rigidbody BallToCopy;
    public float WaitTime = 3f;

    public bool IsHit = false;

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            IsHit = true;
        }

    }

}
