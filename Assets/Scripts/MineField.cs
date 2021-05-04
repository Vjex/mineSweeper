using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineField : MonoBehaviour
{
    //Varibles for Overall Mine Field Requirements
    //amount of Bombs/mines to create 
    public int amountOfMines;

    //Total Now Of Tiles to Create In the Minezfiled i.e : x * y of Minefiled Size we Want.
    public int amountOfTilesUnRevealed;

    
    public bool hasgameStarted = false;


    //Var To get The Max X Values in a Minfiled From 0 and Similarly max y from 0.
    public int xTotal;
    public int yTotal;

    //2D Var For Holding all The Tiles created for minefield.
    public Tile[,] tiles;

    //Var That Hold the No Of Mines Left to discover.
    public int minesLeft = 0;


    //Variables Regarding Timer And Reset Button Of The Game in Top Bar.
    // Timer Script and ResetGameButton Script to Be Assigned At The UI Level That why MAde Public. 
    public Timer timer;

    public ResetGameButton resetGameButton;


    //HighScore Script To set the Hogh Score On Winning A Game.
    public HighScore highScore; 

    //Method To create A New MineFiled (To Start A Game) .
    public void CreateMineField(int xTotal , int yTotal , int amountMines)
    {
        this.xTotal = xTotal;
        this.yTotal = yTotal;
        this.amountOfMines = amountMines;
        this.amountOfTilesUnRevealed = xTotal * yTotal;
        //Set Game Started To False On Every New Mine Filed Creation (A SMineField Will Be Only Created Once Before Starting Every New Game.
        this.hasgameStarted = false;

        //Initially Set The MinesLeft To The Total Mines
        this.minesLeft = amountMines;


        //Whenever New Game Start Reset The Timer Along With Set The Reset Button Face to Neutral
        this.timer.ResetTimer();
        this.resetGameButton.SetNeutral();

        //Now Destroyn=ing previous MineFiled Tils if Created.
        if (tiles != null)
        {

            foreach(Tile tile in tiles)
            {
                Destroy(tile.gameObject);
            }
        }


        //Now Assingning The new  MineField  Total Size of tiles array.
        //basically Creating new 2D Array of tiles for ne MinEfiled.
        this.tiles = new Tile[xTotal, yTotal];

        for(int x = 0; x < xTotal; x++)
        {

            for(int y = 0; y < yTotal; y++)
            {
                tiles[x, y] = Tile.CreateNewTile(x, y);
            }
        }
    }




   //Method To Check Is Player Game Won.
   public bool IsGameWon()
    {
        //If The Amount of Tiles Unrevealed == amouunt of mines it meane player wonth the game else not

        if(this.amountOfTilesUnRevealed == this.amountOfMines)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    //Method To Be Called When A Players Wins The Game.
    //Stop The Timer When Win And Set The Rest Btn Fase to Happy.

    public void WinGame()
    {
        Debug.Log("Game WIn");
        this.timer.StopTimer();
        this.resetGameButton.SetHappy();



        //Now After Winning reveal All the Mines In The Tile 
        //Tile script attached to single tile Prefab has these Varibles . 
        foreach(Tile tile in this.tiles)
        {
            if (tile.isMine)
            {
                tile.spriteController.SetSecuredMineSprite();
            }
        }


        //Upadet The High if Required that Is Checked At HighScore Scriptt Just Passing Current time Of the Timer As A Score.
        this.highScore.UpdateTheHighScore(this.timer.GetCurrentTime());
    }


    //Method To Be Called When A Players Looses The Game.

    //Stop The Timer When Lose And Set The Rest Btn Fase to Sad.
    public void LoosedGame()
    {
        Debug.Log("Game Lost");
        this.timer.StopTimer();
        this.resetGameButton.SetSad();


        //If We Loose The Game Reveal All The Mines Along With Disable The Boxcollider of each tile so that it can not Further clickable.
        foreach (Tile tile in this.tiles)
        {
            if (!tile.isMine)
            {
                tile.GetComponent<BoxCollider2D>().enabled = false;
            }
            else{
                tile.spriteController.SetMineSprite();

            }
        }


    }
}
