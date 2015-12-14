using UnityEngine;
using System.Collections.Generic;

public class Generator : MonoBehaviour {
    public GameObject test;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 5; i++)
        {
            
            int locationX = Random.Range(-3, 3);
            int locationY = Random.Range(-7, -13);
            Instantiate(test);
            //test.speed = 0.5f;
            test.transform.position = new Vector3(locationX, 1, locationY);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
