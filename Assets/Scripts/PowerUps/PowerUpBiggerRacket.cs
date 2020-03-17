using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBiggerRacket : MonoBehaviour
{
    public float multiplier = 2.0f;
    public float duration = 2.0f;
    public Rigidbody Racket;
    public GameObject trihead_guy;


void start()
{
    ;
    trihead_guy.transform.Find("head1");
    trihead_guy.transform.Find("head2");

}
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

        Racket.transform.localScale *= multiplier;

        trihead_guy.transform.Find("body").GetComponent<MeshRenderer>().enabled = false;
        trihead_guy.transform.Find("head1").GetComponent<MeshRenderer>().enabled = false;
        trihead_guy.transform.Find("head2").GetComponent<MeshRenderer>().enabled = false;


        yield return new WaitForSeconds(duration);

        Racket.transform.localScale /= multiplier;

        Destroy(gameObject);

    }


}
