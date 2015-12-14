using UnityEngine;
using System.Collections.Generic;

public class Generator : MonoBehaviour {
    public GameObject test;
	//ball creation algorithm
    //needs to create balls in a triangle
	void Start () {
        //
        int z = 5;
        float offset = 0;

        //begin loop to generate triangle of balls
        for (int i = 0; i < 5; i++)
        {
            for(float j = 0; j < i+1; j++)
            {
                
                createBall(j - offset, z);
            }
            z++;
            offset += 0.5f;
            
        }
    }
	
	//ball create function
    //creates a ball, makes it a rigid body, gives it a location
	void createBall(float x, int z)
    {
        Instantiate(test);
        test.GetComponent<Rigidbody>();
        //test.Rigidbody.mass = 0.5f;
        test.transform.position = new Vector3(x, 1, z);
    }
}
