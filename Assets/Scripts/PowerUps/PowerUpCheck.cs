using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCheck : MonoBehaviour
{

    public PowerUpHitSphere pUSph;
    public PowerUpHitCylinder pUCyl;
    public PowerUpHitCube pUHCube;
    public Rigidbody BallToCopy;
    public GameObject triHead1;
    public GameObject triHead2;
    public GameObject triHead3;
    bool functionCalled = false;
    bool triplicateCalled = false;

    void Update()
    {
        //if every of the three objects is hit
        if(pUSph.IsHitSphere && pUCyl.IsHitCylinder && pUHCube.IsHitCube && !functionCalled)
        {
            Triplicate();
            //this boolean makes sure that triplicate can't get into infinite loop
            functionCalled = true;
        }
    }

    //this function makes two clones of the original ball
    void Triplicate()

    {
        Rigidbody clone;
        if (!triplicateCalled)
            Destroy(triHead1);
            Destroy(triHead2);
            Destroy(triHead3);


        for (int i = 0; i < 2; i++)
        {
           clone = Instantiate(BallToCopy, transform.position, Quaternion.identity);
                //renames all clones to name Ball
                clone.name = "Ball";

        triplicateCalled = true;

        }
    } 
}
