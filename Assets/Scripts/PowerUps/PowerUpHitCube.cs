using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHitCube : MonoBehaviour
{
public bool IsHitCube = false;

public static PowerUpHitCube instance;

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            IsHitCube = true;
            //StartCoroutine (Triplicate());
            Debug.Log("Working!");
        }
   
    }

    void start()
{
    instance = this;
}

/*    int HasHit = 0;

    void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "Ball" && HasHit == 0)
        {
            HasHit = 1;
            Debug.Log(HasHit);
        }
        if (collision.gameObject.tag == "Ball" && HasHit == 1)
        {
            HasHit = 0;
            Debug.Log(HasHit);
        }
    }
    void CheckCounter()
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
