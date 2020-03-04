using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownSmallRacket : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 2.0f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            GetComponent<Animator>().SetTrigger("Hit");

            StartCoroutine(SmallRacket(other));

        }

    }
    //makes ball bigger
    IEnumerator SmallRacket(Collider Ball)
    {

        Racket.transform.localScale *= multiplier;

        yield return new WaitForSeconds(duration);

        Racket.transform.localScale /= multiplier;
    }
}
