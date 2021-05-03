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



    //Method To create A New MineFiled (To Start A Game) .
    public void CreateMineField(int xTotal , int yTotal , int amountMines)
    {
        this.xTotal = xTotal;
        this.yTotal = yTotal;
        this.amountOfMines = amountMines;
        this.amountOfTilesUnRevealed = xTotal * yTotal;
        //Set Game Started To False On Every New Mine Filed Creation (A SMineField Will Be Only Created Once Before Starting Every New Game.
        this.hasgameStarted = false;
    
        //Now Destroyn=ing previous MineFiled Tils if Created.
        if(tiles != null)
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
    public void WinGame()
    {
        Debug.Log("Game WIn");
    }


    //Method To Be Called When A Players Looses The Game.
    public void LoosedGame()
    {
        Debug.Log("Game Lost");
    }
}
