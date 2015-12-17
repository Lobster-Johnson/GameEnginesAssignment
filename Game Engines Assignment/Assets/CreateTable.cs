using UnityEngine;
using System.Collections;

public class CreateTable : MonoBehaviour
{
    public GameObject cue;
    public GameObject wall;
    public GameObject trigger;
    public int height = 9;
    public int width = 7;
    public float elevation = 0.5f;
    public int tableCenter = 3;
    public float offset = 0.75f;

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
        //using the height and table center calculate the final height
        //height 1 represents the upper half of the table
        //height 2 represents the lower half of the table
        int height1 = height + tableCenter;
        int height2 = tableCenter - height;

        

        //inner wall
        //upper and lower wall
        for (int i = -width; i < width + 1; i++)
        {

            //if at a corner, create a wall under it and leave a pocket
            if (i == -width || i == width)
            {
                //start from the bottom, work up creating wall units while leaving space for corner pockets
                for (int j = height2+1; j < height1; j++)
                {
                    //Leave a pocket on the sides at the halfway point
                    if (j != tableCenter)
                    {
                        InnerSideWall(i, j, height1, height2);
                        
                    }
                }
            }
            else
            {
                //upper wall
                InnerTopBottomWalls(i, height1);
                //lower wall
                InnerTopBottomWalls(i, height2);

            }
        }

        //-----------------------------------------------------------
        //create outer wall
        for (int i = -(width+1); i < width + 2; i++)
        {
            OuterWall(i, height1 + 1);
            OuterWall(i, height2 - 1);
            
        }

        //generate triggers
       
        //upper pockets
        generatePockets(-width, height1);
        generatePockets(width, height1);
        //center pockets
        generatePockets(-width, tableCenter);
        generatePockets(width, tableCenter);
        //lower pockets
        generatePockets(-width, height2);
        generatePockets(width, height2);

    }



    //colour in objects passed in
    void colourNext(GameObject obj, int code)
    {
        
        MeshRenderer gameObjectRenderer = obj.GetComponent<MeshRenderer>();
        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.color = Color.white;

        //determine colour
        switch (code)
        {
            //0 = cue ball
            case 0:
                newMaterial.color = Color.white;
                break;

            //1 = floor
            case 1:
                newMaterial.color = new Color32(0, 182, 0, 255);
                break;
            //2 = inner wall
            case 2:
                newMaterial.color = new Color32(0, 102, 0, 255);
                break;
            //3 = outer wall
            case 3:
                newMaterial.color = new Color32(102, 51, 0, 255);
                break;
            //4 = pocket
            case 4:
                newMaterial.color = new Color32(96, 96, 96, 255);
                break;
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



    //create triggers in each pocket
    void generatePockets(int x, int y)
    {
        
        Instantiate(trigger);
        trigger.transform.position = new Vector3(x,-(elevation + 1), y);
        trigger.GetComponent<MeshRenderer>().enabled = false;
        trigger.GetComponent<TriggerScript>();
    }



    //function to create the sides of the inner wall
    void InnerSideWall(int i, int j, int h1, int h2)
    {
        Instantiate(wall);
        wall.transform.position = new Vector3(i, elevation, j);
        

        //make it grey if it's next to a pocket, otherwise make it green
        if (j == tableCenter + 1 || j == tableCenter - 1 || j == h2 + 1 || j == h1 - 1)
        {
            colourNext(wall, 4);
        }
        else
        {
            colourNext(wall, 2);
        }

        //offset the blocks to leave pockets
        //if it's above the center pocket or above the bottom corner pocket, pull it up
        if (j == h2 +1 || j == tableCenter + 1)
        {
            wall.transform.position = new Vector3(i, elevation + 0.01f, j + offset);
        }

        //if it's below the center pocket or below the top pocket, pull it down
        if (j == h1 - 1 || j == tableCenter - 1)
        {
            wall.transform.position = new Vector3(i, elevation + 0.01f, j - offset);
        }
    }



    //create the top and bottom inner walls
    void InnerTopBottomWalls(int i, int c)
    {
        
        Instantiate(wall);
        wall.transform.position = new Vector3(i, elevation, c);

        //if it's next to a pocket make it grey, otherwise make it green
        if (i == width - 1 || i == -width + 1)
        {
            colourNext(wall, 4);
        }
        else
        {
            colourNext(wall, 2);
        }
        //if next to right corner pocket, pull to the left
        if (i == width - 1)
        {
            wall.transform.position = new Vector3(i - offset, elevation + 0.01f, c);
        }
        //if next to left corner pocket, pull to the right
        if(i == -width + 1)
        {
            wall.transform.position = new Vector3(i + offset, elevation + 0.01f, c);
        }
    }



    //create the outer walls of the pool table
    void OuterWall(int i, int hUsed)
    {
        int height1 = height + tableCenter;
        int height2 = tableCenter - height;

        Instantiate(wall);
        wall.transform.position = new Vector3(i, elevation, hUsed);
        colourNext(wall, 3);

        //if at a corner, create a wall under it
        if (i == -(width + 1) || i == (width + 1))
        {
            for (int j = height2; j < height1 + 1; j++)
            {

                Instantiate(wall);
                wall.transform.position = new Vector3(i, elevation, j);
                colourNext(wall, 3);

            }
        }
    }

}
