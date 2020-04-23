using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHitSphere : MonoBehaviour
{
    public bool IsHitSphere = false;
    public static PowerUpHitSphere instance;
    public GameObject triHead;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            IsHitSphere = true;

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
