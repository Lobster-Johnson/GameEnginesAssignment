using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
    //if an object enters this pocket
    
    void OnTriggerStay(Collider other)
    {
        //if an object enters, give a debug message and launch it into the air
        Debug.Log("Got one!");
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up*1000, ForceMode.Acceleration);
    }
}
