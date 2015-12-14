using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour {
    public float speed = 1.0f;
	
	// Update is called once per frame
	void Update () {
        float moveX = (Input.acceleration.x * speed);
        float moveY = (Input.acceleration.y * speed);
        transform.Translate(moveX, 0, moveY);
    }
}
