using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
    //if an object enters this pocket
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Got one!");
    }
}
