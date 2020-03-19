using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PowerDownInvisibleBall : MonoBehaviour
{
    public float duration = 2.0f;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            GetComponent<Animator>().SetTrigger("Hit");

            StartCoroutine(Invisible(other));

        }

    }

    IEnumerator Invisible(Collider Ball)
    {
        //MeshRenderer meshRenderer = GetComponent<meshRenderer>();

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;

        yield return new WaitForSeconds(duration);

        GetComponent<MeshRenderer>().enabled = true;
    }

}
