using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHitSphere : MonoBehaviour
{
public bool IsHitSphere = false;
public static PowerUpHitSphere instance;

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            IsHitSphere = true;
            //StartCoroutine (Triplicate());
            Debug.Log("Working!");
        }
}
void start()
{
    instance = this;
}

}