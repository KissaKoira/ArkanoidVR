using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDublicate : MonoBehaviour
{

    public GameObject Ball;
    public Rigidbody BallToCopy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            Triplicate();
        }

    }
    void Triplicate()
    {


        for (int i = 0; i < 2; i++)
        {
            Instantiate(BallToCopy, new Vector3(i * 0.5F, 0f, 0f), Quaternion.identity);
        }
    

    
    }

}
