using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
    static int score = 0;
    static string message = "";
	
    //draw a message box
    void OnGUI()
    {
        
        GUI.Label(new Rect(10, 20, 100, 40), "Score: " + score + "\n" + message);
    }

    //if the player scores give them a point
    public static void increaseScore(int i)
    {
        score += i;
    }

    //if the player loses tell them
    public static void lose()
    {
        message = "Game Over.";
    }
}
