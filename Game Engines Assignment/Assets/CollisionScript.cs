﻿using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {
    public AudioClip clack;
    AudioSource audio;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Bang");
        audio = GetComponent<AudioSource>();
        //if a ball hits either another ball or the cue, play this sound
        if (col.gameObject.tag == "Ball" || col.gameObject.tag == "Cue Ball")
        {
            audio.PlayOneShot(clack, 0.01f);
        }
        
    }
}
