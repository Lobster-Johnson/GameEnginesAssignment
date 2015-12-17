using UnityEngine;
using System.Collections.Generic;

public class Generator : MonoBehaviour
{
    public GameObject ball;
	//ball creation algorithm
    //needs to create balls in a triangle
	void Start ()
    {
        //represents rows
        int z = 5;
        //current ball number
        int ballnumber = 1;
        //offset to put balls in a pyramid shape
        float offset = 0;

        //begin loop to generate triangle of balls
        for (int i = 0; i < 5; i++)
        {
            for(float j = 0; j < i+1; j++)
            {
                
                createBall(j - offset, z, ballnumber);
                ballnumber++;
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
        Color red = new Color(255,0,0);
        Color yellow = new Color(255,255,0);
        Color black = new Color(0,0,0);
        MeshRenderer gameObjectRenderer = ball.GetComponent<MeshRenderer>();
        Material newMaterial = new Material(Shader.Find("Standard"));

        //if the number is 5, it's the black ball
        //if the number is odd, it's yellow
        //if the number is even, it's red
        if(number == 5)
        {
            //ball.tag = "Black";
            newMaterial.color = black;
        }
        else if (number % 2 == 1)
        {
            newMaterial.color = yellow;
        }
        else if(number % 2 == 0)
        {
            newMaterial.color = red;
        }
        
        gameObjectRenderer.material = newMaterial;
    }
}
