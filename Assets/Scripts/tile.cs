using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    float counter = 0;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            //sets tile's color to red
            this.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 0, 0, 1));
            counter = 0.5f;
        }
    }

    private void Update()
    {
        //changes tiles color back after 0.5 seconds
        if(counter > 0)
        {
            counter -= Time.deltaTime;
        }

        if(counter < 0)
        {
            counter = 0;

            this.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 1, 1, 1));
        }
    }
}
