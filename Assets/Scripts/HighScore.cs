using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    //varibles Regarding HighScore Of Each Mode Of Game.
    //Note * : HighScore Is The VAlue Of Timer.
    public int highScoreEasy;
    public int highScoreMedium;
    public int highScoreHard;

    //Varible for Hogh Score Text That Will Be Assigned At the UI Level To Change Its Text Vaue with The highScore.
    public Text highScoreText;

    //DifficultyButton Script var To Get he Current Difficulty Of GAme to save and get teh HighScore Accordingly.
    public DifficultyButtons difficultyButtons;



    // Start is called before the first frame update
    void Start()
    {

        //Initially get the Previoius HoghScore If Already Set.

        //Easy
        if (PlayerPrefs.HasKey("HighScoreEasy"))
        {
            this.highScoreEasy = PlayerPrefs.GetInt("HighScoreEasy");
        }
        else
        {
            this.highScoreEasy = 999;
        }
        //Medium
        if (PlayerPrefs.HasKey("HighScoreMedium"))
        {
            this.highScoreMedium = PlayerPrefs.GetInt("HighScoreMedium");
        }
        else
        {
            this.highScoreMedium = 999;
        }
        //Hard
        if (PlayerPrefs.HasKey("HighScoreHard"))
        {
            this.highScoreHard = PlayerPrefs.GetInt("HighScoreHard");
        }
        else
        {
            this.highScoreHard = 999;
        }


        
    }

    //Now Update The High Score text According to Difficulty Level.
    void FixedUpdate()
    {
        if (this.difficultyButtons.difficultyLevel == "EASY")
        {
            this.highScoreText.text = this.highScoreEasy.ToString();
        }
        else if (this.difficultyButtons.difficultyLevel == "MEDIUM")
        {
            this.highScoreText.text = this.highScoreMedium.ToString();

        }
        else if (this.difficultyButtons.difficultyLevel == "HARD")
        {
            this.highScoreText.text = this.highScoreHard.ToString();

        }
    }


    //Method To Save the High Accordingly to Player Prefs Accordingly of Needed.

    public void UpdateTheHighScore(int score)
    {
        if(this.difficultyButtons.difficultyLevel == "EASY")
        {

            if (score < highScoreEasy)
            {
                this.highScoreEasy = score;

                //Set the Easy HighScore
                PlayerPrefs.SetInt("HighScoreEasy", score);
            }
        }
        else if (this.difficultyButtons.difficultyLevel == "MEDIUM")
        {
            if (score < highScoreMedium)
            {
                this.highScoreMedium = score;

                //Set the Easy HighScore
                PlayerPrefs.SetInt("HighScoreMedium", score);
            }
        }
        else if (this.difficultyButtons.difficultyLevel == "HARD")
        {
            //Checking if The New Score Is Shorter the Previous Timer Text High Score only then Save
            if(score < highScoreHard)
            {
                this.highScoreHard = score;

                //Set the Easy HighScore
                PlayerPrefs.SetInt("HighScoreHard", score);
            }
           
        }

        //Save The High Score To PlayerPrefs
        PlayerPrefs.Save();

    }


    //Method To Reset The Hgh Score.

    public void resetHighScore()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        this.highScoreEasy = 999;
        this.highScoreMedium = 999;
        this.highScoreHard = 999;
    }
}
