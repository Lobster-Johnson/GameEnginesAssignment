using UnityEngine;
using System.Collections;

public class CreateTable : MonoBehaviour {
    public GameObject cue;
    public GameObject table;
    public GameObject wall;

	// Use this for initialization
	void Start ()
    {
        //generate cueball
        generateCueBall();

        //table generation
        generateTable();

	}

    void generateCueBall()
    {
        Instantiate(cue);
        cue.transform.position = new Vector3(0, 0.5f, 0);
    }

    void generateTable ()
    {
        //create and scale table
        Instantiate(table);
        table.transform.position = new Vector3(0, 0, 3);
        table.transform.localScale = new Vector3(1.5f, 1, 1.5f);
        
        //create walls and pockets
        //these are really hardcoded, change them you ameteur

        //upper wall
        for (int i = -7; i < 7; i++)
        {
            Instantiate(wall);
            wall.transform.position = new Vector3(i, 0.5f, 10);
        }

        //lower wall
        for (int i = -7; i < 7; i++)
        {
            Instantiate(wall);
            wall.transform.position = new Vector3(i, 0.5f, -4);
        }
        //left wall
        for (int i = -3; i < 10; i++)
        {
            Instantiate(wall);
            wall.transform.position = new Vector3(-8, 0.5f, i);
        }
        //right wall
        for (int i = -3; i < 10; i++)
        {
            Instantiate(wall);
            wall.transform.position = new Vector3(8, 0.5f, i);
        }
    }
}
