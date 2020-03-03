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
            //StartCoroutine (Triplicate());
            Debug.Log("Working!");
        }

    }
    
    /*IEnumerator Triplicate()
    {
        Rigidbody clone;

        for (int i = 0; i < 2; i++)
        {
           clone = Instantiate(BallToCopy, new Vector3(i * 0.5F, 0f, 0f), Quaternion.identity);

            yield return new WaitForSeconds(WaitTime);
        }
    

    
    } */

}
