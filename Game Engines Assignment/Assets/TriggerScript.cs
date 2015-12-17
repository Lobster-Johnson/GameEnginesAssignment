using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
    //if an object enters this pocket
    public AudioClip applause;
    public AudioClip boo;
    AudioSource audio;

    void OnTriggerEnter(Collider col)
    {
        //if an object enters, give a debug message and launch it straight down
        Debug.Log("Got one!");
        Rigidbody rb = col.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down*1000, ForceMode.Acceleration);
        audio = GetComponent<AudioSource>();

        //get the object tag
        switch (col.gameObject.tag)
        {
            case "Ball":
                Debug.Log("Ball");
                //play applause
                audio.PlayOneShot(applause, 0.5f);
                break;

            case "CueBall":
                Debug.Log("Cue ball");
                //play boo
                audio.PlayOneShot(boo, 0.5f);
                break;
            case "Black":
                Debug.Log("Black");
                //play boo
                audio.PlayOneShot(boo, 0.5f);
                break;
        }
    }
}
