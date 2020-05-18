using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public GameObject player;
    public GameObject currentBall;
    public GameObject ballPrefab;

    float counter = 0;

    private void Update()
    {
        if(counter > 0)
        {
            counter -= Time.deltaTime;
        }

        if (counter < 0)
        {
            GameObject newBall = Instantiate(ballPrefab);
            newBall.transform.position = this.transform.position;
            currentBall = newBall;

            counter = 0;
        }
    }

    public void spawnBall()
    {
        counter = 1;
    }
}
