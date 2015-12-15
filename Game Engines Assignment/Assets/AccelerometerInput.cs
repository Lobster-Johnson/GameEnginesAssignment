using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour {
    public float speed = 5f;
    public Rigidbody rb;
	
	// Use the gyroscope to move the balls about
    //needs force instead of transforms to make phsyics work
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
        


        //Backup controls
        //float moveX = (Input.acceleration.x * speed);
        //float moveY = (Input.acceleration.y * speed);
        //transform.Translate(moveX, 0, moveY);

    }
}
