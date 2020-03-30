using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownSmallRacket : MonoBehaviour
{
    public float multiplier = 0.5f;
    public float duration = 2.0f;
    public Rigidbody Racket;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            //GetComponent<Animator>().SetTrigger("Hit");

            StartCoroutine(SmallRacket(other));

        }

    }
    //makes racket smaller
    IEnumerator SmallRacket(Collider other)
    {
        //Debug.Log("Smaller Racket");

        Racket.transform.localScale *= multiplier;

        yield return new WaitForSeconds(duration);

        Racket.transform.localScale /= multiplier;


    }
}
