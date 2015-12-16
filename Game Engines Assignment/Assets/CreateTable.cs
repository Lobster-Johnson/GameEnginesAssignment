using UnityEngine;
using System.Collections;

public class CreateTable : MonoBehaviour
{
    public GameObject cue;
    public GameObject table;
    public GameObject wall;
    public int height = 9;
    public int width = 7;
    public float elevation = 0.5f;
    public int tableCenter = 3;

	// Use this for initialization
	void Start ()
    {
        //generate cueball
        generateCueBall();
        //create table floor
        generateFloor();
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
        //Color white = new Color(255, 255, 255);
        MeshRenderer gameObjectRenderer = cue.GetComponent<MeshRenderer>();
        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.color = Color.white;
        gameObjectRenderer.material = newMaterial;
    }

    //generate the walls of the table
    void generateTable ()
    {
        //create and scale table
        //Instantiate(table);
        //table.transform.position = new Vector3(0, 0, tableCenter);
        //table.transform.localScale = new Vector3(1.5f, 1, 1.5f);
        

        
        int corner1 = height + tableCenter;
        int corner2 = tableCenter - height;

        //inner wall
        //upper and lower wall
        for (int i = -width; i < width + 1; i++)
        {

            //if at a corner, create a wall under it and leave a pocket
            if (i == -width || i == width)
            {
                //start from the bottom, work up creating wall units
                for (int j = corner2; j < corner1+1; j++)
                {
                    //if halfway through leave a pocket
                    if (j != tableCenter)
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
                wall.transform.position = new Vector3(i, elevation, corner1);
                //lower wall
                Instantiate(wall);
                wall.transform.position = new Vector3(i, elevation, corner2);
            }
        }

        //-----------------------------------------------------------
        //create outer wall
        for (int i = -(width+1); i < width + 2; i++)
        {
            //upper wall
            Instantiate(wall);
            wall.transform.position = new Vector3(i, elevation, corner1+1);
            colourNext(wall);

            //lower wall
            Instantiate(wall);
            wall.transform.position = new Vector3(i, elevation, corner2-1);
            colourNext(wall);

            //if at a corner, create a wall under it
            if (i == -(width+1) || i == (width+1))
            {
                for (int j = corner2; j < corner1+1; j++)
                {
                   
                    Instantiate(wall);
                    wall.transform.position = new Vector3(i, elevation, j);
                    colourNext(wall);
                    
                }
            }
        }
       }

    //colour in objects passed in
    void colourNext(GameObject obj)
    {
        //Color brown = new Color(205, 133, 0);
        MeshRenderer gameObjectRenderer = obj.GetComponent<MeshRenderer>();
        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.color = Color.black;
        gameObjectRenderer.material = newMaterial;
    }

    //using height and width create a surface for the pool table
    void generateFloor()
    {
        int w = width - 1;
        int h1 = (height + tableCenter);
        int h2 = (tableCenter - height) + 1;

        for(int i = -w; i < width; i++)
        {
            for(int j = h2; j < h1; j++)
            {
                Instantiate(wall);
                wall.transform.position = new Vector3(i, -elevation, j);
            }
        }
    }
}
