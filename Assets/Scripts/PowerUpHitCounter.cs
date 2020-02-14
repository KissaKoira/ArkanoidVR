using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHitCounter : MonoBehaviour
{
    int HasHit = 0;

    void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            HasHit = !HasHit;
            //CheckCounter();
        }
    }
/*    void CheckCounter()
    {
        if(HasHit == false)
        {
            HasHit = true;
            Debug.Log("TRUE!");
        }
        else if(HasHit == true)
        {
            HasHit = !HasHit;
            Debug.Log("FALSE!");
        }
    } */
}
