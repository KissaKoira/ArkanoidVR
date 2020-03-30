using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCheck : MonoBehaviour
{

public PowerUpHitSphere pUSph;
public PowerUpHitCylinder pUCyl;
public PowerUpHitCube pUHCube;
public Rigidbody BallToCopy;
bool functionCalled = false;
bool triplicateCalled = false;

    void Update()
    {
        //jos sylinteriin, palloon ja kuutioon on osuttu
        if(pUSph.IsHitSphere && pUCyl.IsHitCylinder && pUHCube.IsHitCube && !functionCalled)
        {
            Triplicate();
            //should change booleans back to false but does not do that
            functionCalled = true;
        }
    }

//Triplicate makes more balls but its infinite right now because upper if wont work
    void Triplicate()

    {
        Rigidbody clone;
        if(!triplicateCalled)


        for (int i = 0; i < 2; i++)
        {
           clone = Instantiate(BallToCopy, new Vector3(i * 0.5F, 0f, 0f), Quaternion.identity);

            //yield return new WaitForSeconds(WaitTime);
        triplicateCalled = true;
        }
    } 
}
