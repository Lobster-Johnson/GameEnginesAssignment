using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
    
    public AudioClip applause;
    public AudioClip boo;
    AudioSource audio;
    static bool lost = false;

    //if an object enters this pocket
    void OnTriggerEnter(Collider col)
    {
        
        //if an object enters, launch it straight down
        Rigidbody rb = col.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down * 1000, ForceMode.Acceleration);
        audio = GetComponent<AudioSource>();

        //get the object tag
        switch (col.gameObject.tag)
        {
            case "Ball":
                //play applause if the user hasn't lost
                if (lost == false)
                {
                    Score.increaseScore(1);
                    audio.PlayOneShot(applause, 0.5f);
                }
                break;

                //if the player pots the cue they lose. Boo them
            case "CueBall":
                //play boo
                lost = true;
                Score.lose();
                audio.PlayOneShot(boo, 0.5f);
                break;

            }
        

        
    }
    
}
