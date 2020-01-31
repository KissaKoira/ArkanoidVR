﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 2.0f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            GetComponent<Animator>().SetTrigger("Hit");

            StartCoroutine(Pickup(other));

        }

    }
    IEnumerator Pickup(Collider Ball)
    {

        Ball.transform.localScale *= multiplier;

        yield return new WaitForSeconds(duration);

        Ball.transform.localScale /= multiplier;
    }

}