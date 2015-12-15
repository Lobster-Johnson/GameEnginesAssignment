using UnityEngine;
using System.Collections.Generic;

public class Generator : MonoBehaviour
{
    public GameObject ball;
	//ball creation algorithm
    //needs to create balls in a triangle
	void Start ()
    {
        
        int z = 5;
        float offset = 0;

        //begin loop to generate triangle of balls
        for (int i = 0; i < 5; i++)
        {
            for(float j = 0; j < i+1; j++)
            {
                
                createBall(j - offset, z, i);
            }
            z++;
            offset += 0.5f;
            
        }
    }
	
	//ball create function
    //creates a ball, makes it a rigid body, gives it a location
	void createBall(float x, int z, int number)
    {
        Instantiate(ball);
        ball.GetComponent<Rigidbody>();
        ball.transform.position = new Vector3(x, 1, z);

        //colour based on number
    }
}
