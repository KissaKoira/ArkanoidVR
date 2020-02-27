using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCheck : MonoBehaviour
{

public PowerUpHitSphere pUSph;
public PowerUpHitCylinder pUCyl;
public PowerUpHitCube pUHCube;
    public Rigidbody BallToCopy;

    void Update()
    {
        if(pUSph.IsHitSphere && pUCyl.IsHitCylinder && pUHCube.IsHitCube)
        {
        /*    Triplicate();
            IsHitSphere == false;
            IsHitCylinder == false;
            IsHitCube == false;
        }
    }

    void Triplicate()

    {
        Rigidbody clone;

        for (int i = 0; i < 2; i++)
        {
           clone = Instantiate(BallToCopy, new Vector3(i * 0.5F, 0f, 0f), Quaternion.identity);

            //yield return new WaitForSeconds(WaitTime);

        }
    } */
}
