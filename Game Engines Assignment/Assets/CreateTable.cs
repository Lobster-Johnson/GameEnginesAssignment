using UnityEngine;
using System.Collections;

public class CreateTable : MonoBehaviour
{
    public GameObject cue;
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
        colourNext(cue, 0);
    }

    //generate the walls of the table
    void generateTable ()
    {
        
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
                for (int j = corner2+1; j < corner1; j++)
                {
                    //Leave pockets
                    if (j != tableCenter)
                    {
                        Instantiate(wall);
                        wall.transform.position = new Vector3(i, elevation, j);

                        //make it grey if it's next to a pocket, otherwise make it green
                        if (j == tableCenter + 1 || j == tableCenter - 1 || j == corner2 +1 || j == corner1 -1)
                        {
                            colourNext(wall, 4);
                        }
                        else
                        {
                            colourNext(wall, 2);
                        }
                    }
                }
            }
            else
            {
                
                //upper wall
                Instantiate(wall);
                wall.transform.position = new Vector3(i, elevation, corner1);
                if (i == width - 1 || i == -width + 1)
                {
                    colourNext(wall, 4);
                }
                else
                {
                    colourNext(wall, 2);
                }
                
                //lower wall
                Instantiate(wall);
                wall.transform.position = new Vector3(i, elevation, corner2);
                if (i == width - 1 || i == -width + 1)
                {
                    colourNext(wall, 4);
                }
                else
                {
                    colourNext(wall, 2);
                }

            }
        }

        //-----------------------------------------------------------
        //create outer wall
        for (int i = -(width+1); i < width + 2; i++)
        {
            //upper wall
            Instantiate(wall);
            wall.transform.position = new Vector3(i, elevation, corner1+1);
            colourNext(wall, 3);

            //lower wall
            Instantiate(wall);
            wall.transform.position = new Vector3(i, elevation, corner2-1);
            colourNext(wall, 3);

            //if at a corner, create a wall under it
            if (i == -(width+1) || i == (width+1))
            {
                for (int j = corner2; j < corner1+1; j++)
                {
                   
                    Instantiate(wall);
                    wall.transform.position = new Vector3(i, elevation, j);
                    colourNext(wall, 3);
                    
                }
            }
        }
       }

    //colour in objects passed in
    void colourNext(GameObject obj, int code)
    {
        
        MeshRenderer gameObjectRenderer = obj.GetComponent<MeshRenderer>();
        Material newMaterial = new Material(Shader.Find("Standard"));
        
        //determine colour
        //0 = cue ball
        if (code == 0)
        {
            newMaterial.color = Color.white;
        }
        //1 = floor
        if(code == 1)
        {
            newMaterial.color = new Color32(0, 182, 0, 255); 
        }
        //2 = wall
        if (code == 2)
        {
            newMaterial.color = new Color32(0, 102, 0, 255);
        }
        //3 = outer wall
        if(code == 3)
        {
            newMaterial.color = new Color32(102,51,0, 255);
        }
        //4 = pocket
        if(code == 4)
        {
            newMaterial.color = new Color32(96, 96, 96, 255);
        }
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
                colourNext(wall, 1);
            }
        }
    }
}
