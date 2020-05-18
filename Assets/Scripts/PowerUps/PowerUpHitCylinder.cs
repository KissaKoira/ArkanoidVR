using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHitCylinder : MonoBehaviour
{
    public bool IsHitCylinder = false;
    public static PowerUpHitCylinder instance;
    public GameObject triHead;

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            IsHitCylinder = true;

            //Hides the triheadguy when ball has hit to it
            foreach (MeshRenderer r in triHead.GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
        }
}

void start()
{
    instance = this;
}

}