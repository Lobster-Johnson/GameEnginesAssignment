using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour {
    public float speed = 1.0f;
	
	// Use the gyroscope to move the balls about
    //needs force instead of transforms to make phsyics work
	void Update () {
        float moveX = (Input.acceleration.x * speed);
        float moveY = (Input.acceleration.y * speed);
        transform.Translate(moveX, 0, moveY);

        //Physics.gravity = new Vector3(moveX, 0, moveY);
    }
}
