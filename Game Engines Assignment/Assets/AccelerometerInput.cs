using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour {
    public float speed = 5f;
    public Rigidbody rb;
	
	// Use the gyroscope to move the balls about
    //Gets the tilt of the device and translates it into a force on the ball
	void Update () {
        
       
            Vector3 movement = new Vector3();
            movement.x = Input.acceleration.x;
            movement.z = -Input.acceleration.z;

            if (movement.sqrMagnitude > 1)
            {
                movement.Normalize();
            }
            rb = GetComponent<Rigidbody>();

            rb.AddForce(movement * speed);
        


        

    }
}
