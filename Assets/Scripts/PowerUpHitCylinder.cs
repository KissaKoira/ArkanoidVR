using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHitCylinder : MonoBehaviour
{
public bool IsHitCylinder = false;

public static PowerUpHitCylinder instance;

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            IsHitCylinder = true;
            //StartCoroutine (Triplicate());
            Debug.Log("Working!");
        }
}

void start()
{
    instance = this;
}

}