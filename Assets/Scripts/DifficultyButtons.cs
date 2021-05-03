using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour
{
    //This Script is Assigned to Bottom Bar As It Containes All the Difficult Buttons.

    //var Of Minefiled Script Object Assingned To MineField GameObject
    MineField mineField;

    //var to Check In Which Currrent Difficulty level game is (By Default  == "EASEY";

    string difficultyLevel = "EASY";

    void Start()
    {
        //Initilaising 
        this.mineField = GameObject.FindGameObjectWithTag("Minefield").GetComponent<MineField>();

        //Initilay call For Easy Mode 
        SetEasy();
    }

    //Method To Set The Game in Easy Mode.

    public void SetEasy()
    {
        //calling the Create New MineFiled Method Defined Inside MineField Script.
        this.mineField.CreateMineField(10, 10, 10);

        //Setting Current Game Difficulty Level.
        this.difficultyLevel = "EASY";

    }

    //Method To Set The Game in Medium Mode.

    public void SetMedium()
    {
        //calling the Create New MineFiled Method Defined Inside MineField Script.
        this.mineField.CreateMineField(20, 20, 40);

        //Setting Current Game Difficulty Level.
        this.difficultyLevel = "MEDIUM";

    }


    //Method To Set The Game in Hard Mode.

    public void SetHard()
    {
        //calling the Create New MineFiled Method Defined Inside MineField Script.
        this.mineField.CreateMineField(40, 30, 60);

        //Setting Current Game Difficulty Level.
        this.difficultyLevel = "HARD";

    }

    //Method To Rest The Game in Current Difficulty Level

    public void ResetGame()
    {
        if(this.difficultyLevel == "EASY")
        { 
             SetEasy();
        }
        else if (this.difficultyLevel == "MEDIUM")
        {
            SetMedium();
        }
        else if (this.difficultyLevel == "HARD")
        {
            SetHard();
        }
    }
}
