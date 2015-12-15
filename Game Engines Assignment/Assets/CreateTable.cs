using UnityEngine;
using System.Collections;

public class CreateTable : MonoBehaviour
{
    public GameObject cue;
    public GameObject table;
    public GameObject wall;
    public int height;
    public int width = 7;
    public float elevation = 0.5f;

	// Use this for initialization
	void Start ()
    {
        //generate cueball
        generateCueBall();

        //table generation
        generateTable();

	}

    //generate cue ball and make it white
    void generateCueBall()
    {
        //generate cue at this position
        Instantiate(cue);
        cue.transform.position = new Vector3(0, elevation, 0);

        //set the cue ball to a white colour
        Color white = new Color(255, 255, 255);
        MeshRenderer gameObjectRenderer = cue.GetComponent<MeshRenderer>();
        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.color = white;
        gameObjectRenderer.material = newMaterial;
    }

    //generate the entire table
    void generateTable ()
    {
        //create and scale table
        Instantiate(table);
        table.transform.position = new Vector3(0, 0, 3);
        table.transform.localScale = new Vector3(1.3f, 1, 1.3f);
        
        //create inner walls and pockets
        //these are really hardcoded, change them you ameteur

        //upper and lower wall
        for (int i = -width; i < width+1; i++)
        {
            
            //if at a corner, create a wall under it and leave a pocket
            if (i == -width || i == width)
            {
                for (int j = -3; j < 10; j++)
                {
                    //if halfway through leave a pocket
                    if (j != 4)
                    {
                        Instantiate(wall);
                        wall.transform.position = new Vector3(i, elevation, j);
                    }
                }
            }
            else
            {
                //upper wall
                Instantiate(wall);
                wall.transform.position = new Vector3(i, elevation, 10);
                //lower wall
                Instantiate(wall);
                wall.transform.position = new Vector3(i, elevation, -4);
            }
        }

        //-----------------------------------------------------------
        //create outer wall
        for (int i = -(width+1); i < width + 2; i++)
        {
            //upper wall
            Instantiate(wall);
            wall.transform.position = new Vector3(i, elevation, 11);
            //lower wall
            Instantiate(wall);
            wall.transform.position = new Vector3(i, elevation, -5);

            //if at a corner, create a wall under it
            if (i == -(width+1) || i == (width+1))
            {
                for (int j = -4; j < 11; j++)
                {
                   
                    Instantiate(wall);
                    wall.transform.position = new Vector3(i, elevation, j);
                    
                }
            }
        }
       }
}
