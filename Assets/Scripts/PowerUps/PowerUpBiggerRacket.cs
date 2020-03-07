using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBiggerRacket : MonoBehaviour
{
    public float multiplier = 2.0f;
    public float duration = 2.0f;
    public Rigidbody Racket;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            //GetComponent<Animator>().SetTrigger("Hit");

            StartCoroutine(BigRacket(other));

        }

    }
    //makes racket bigger
    IEnumerator BigRacket(Collider other)
    {
        //Debug.Log("WHAAT?");

        Racket.transform.localScale *= multiplier;

        yield return new WaitForSeconds(duration);

        Racket.transform.localScale /= multiplier;


    }
}
