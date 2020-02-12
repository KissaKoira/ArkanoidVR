using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDublicate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            Dublicate();

        }

    }
    Dublicate(Collider Ball)
    {

        BallInstance = 

        yield return new WaitForSeconds(duration);

        Ball.transform.localScale /= multiplier;
    }

}
