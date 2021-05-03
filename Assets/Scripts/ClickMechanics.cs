using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMechanics : MonoBehaviour
{
    // Note ** : This Script Is Assigned to Tile Prefab.

    //Var Required To Handle The Clicke Mechanics Are The Script Var .
    MineField mineField;
    SpriteController spriteController;
    Tile tile;

    // Start is called before the first frame update
    void Start()
    {
        this.mineField = GameObject.FindGameObjectWithTag("Minefield").GetComponent<MineField>();

        //We Are Not Finding These Two Script Through Game Object as The Two Script Assigned to the Same Object To This ClickMechanics Script is i.e Tile Prefab.
        this.spriteController = this.GetComponent<SpriteController>();
        this.tile = this.GetComponent<Tile>();

    }



    //Inbuilt Method To be Called Automaticaaly on Lefy Click Of Mouse.
    //Called The Click Tile Method
    private void OnMouseUpAsButton()
    {
        this.ClickTile();
    }


    //Inbuilt Method To Be Called Automatically on  Click of Mouse

    //On Right Click Set The Tile As Secured Through Sprite Controller Script.
    private void OnMouseOver()
    {
        //Pass One To Get The Righ Click is Pressed
        if (Input.GetMouseButtonDown(1))
        {

            //Checking that if The Tile Is Already Seacure The Set it to again default tile otherwise set the tile as secured Tile.
            if (this.tile.isSecured) {

                //Setting the Particular tile as  Unssecured along with changing variable of isSecured to False For That Particular tile On Which Right Mouse Btn clicked.
                this.spriteController.SetDefaultTileSprite();

                this.tile.isSecured = false;
            }
            else
            {
                //Setting the Particular tile a ssecured along with changing variable of isSecured to Ture For That Particular tile On Which Right Mouse Btn clicked.
                this.spriteController.SetSecuredTileSprite();

                this.tile.isSecured = true;


            }
        }
    }



    //method To Be Called On Click to Any Single Tile.
    void ClickTile()
    {

        if (!this.mineField.hasgameStarted)
        {
            //Set The GAme Is Started so that Next Time on Click CreateMines Method Not Called.
            this.mineField.hasgameStarted = true;


            //Now Create Mine As The Game Not Started 
            this.CreateMines();
        }



        ////Now Further.
        //Checking That Is Game Over or We Have Won On Every Click
        if (this.tile.isMine)
        {


            //If The Clicked Tile is A Mine Then It Means Player Loosed The Game.

            //Callling Loose Game Method
            this.mineField.LoosedGame();
        }else
        {
            //Reveal The New Tile and Also Check If The Playes Won The Game Or Not.

            this.RevealTile();


            //Now Every Time We Reveal the Tiles WE are Checking after Revealing that If Player Won the Game The show Won Message By Calling Win Game Method In minefield Script.

            if (this.mineField.IsGameWon())
            {
                this.mineField.WinGame();
            }
        }
    }



    //Method To Create The Mines Before Started the Every New GAme 
    void CreateMines()
    {
        Debug.Log("Creating Mines");

        int mineLeft = this.mineField.amountOfMines;
        int tileLeft = this.mineField.amountOfTilesUnRevealed;


        //Double on Total Lenght Of The MineFiled To Randomly Decide Which Tile IS To be Reolaced By A Mine.

        for(int x =0; x < this.mineField.xTotal; x++)
        {
            for(int y =0; y < this.mineField.yTotal; y++)
            {

                //First We Have To Ensure That Tile On Which Clicked is Not A Mine.

                if(!(x == this.tile.x && y == this.tile.y))
                {
                    //get The Particiular X,y Postion Tile Value From the 2D Array In Minefield of Tiles.
                    Tile aTile = this.mineField.tiles[x, y];

                    //Creating a random Chance Var To Descide The Particiular Tile Should be a Mine Or Not
                    //casting to Float To Ensure To get The Float Value
                    float chanceForMine = (float)mineLeft / (float)tileLeft;

                    //getting a Random Values and Comparing to Our Total Cjance of Mine.
                    //So This Will Create Diffrent Tile Mines Every Time CreateMine Called.
                    if(Random.value <= chanceForMine)
                    {
                        //Setting that particular Tile As a Mine 
                        aTile.isMine = true;

                        //Decrease the mine Meft Var To Create diffrent Chances value.
                        mineLeft--;


                    }

                }


                //Now Also Decreae The Tile Left on Each Loop

                tileLeft--;
            }
        }


    }


    //Method To Be Callled To Reveal A Tile if Not Revealed Previously.
    public void RevealTile()
    {
        //Validating revealing can be done or not
        if(!this.tile.isRevealed && !this.tile.isMine)
        {
            //Now Set this Tile As Revealed So that it can Not be Revealed Again on click.
            this.tile.isRevealed = true;

            //Decrease the Amoungt of Tile Unrevealed from minefiled Script.
            this.mineField.amountOfTilesUnRevealed--;

            //No Get The Amount OF Neighbouring Mines To That Particular Mine and It Can Be MAx 8 Mines As A Tile Maximum can have 8 neighbours in all 2D Directions.

            int amountNeighbouringMines = this.GetAmountNeighbouredMines();

            //Now Set The Emply Tile Sprite Of The Partcular Tile Depending on The No of Neighbouring mines .
            this.spriteController.SetEmptyTileSprite(amountNeighbouringMines);

            //Call The Reveal If Valid Method For All Its Neighbouring Tiles i.e maximum == 8.
            //but only if there is no mines OR 0 mines in its Neighbour.
            //*****************************************************IMPORTANT************************************************************//
            //**************************************************************************************************************************************//
            //**************************************************************************************************************************************//

            //Now What Will Happen :
            //This Will Call RevealifValid for All its Neighbour if amount of neighbours is zero and that method will again call this Reveal method By the ClickMechanics Varibles Provided to Each Tile for That Particular tile .
            //And This Loop Of Calling the Same Method Will Repeade untill each direct has Not At least one mine Found and not Exceeds The Boundary Value.
            if (amountNeighbouringMines == 0)
            {
                //Calling RevealIfMethod For All Its Eight Neighbouring Tiles.

                this.RevealIfValid(this.tile.x - 1, this.tile.y - 1);
                this.RevealIfValid(this.tile.x - 1, this.tile.y );
                this.RevealIfValid(this.tile.x - 1, this.tile.y + 1);

                this.RevealIfValid(this.tile.x, this.tile.y - 1);
                this.RevealIfValid(this.tile.x , this.tile.y + 1);
                
                this.RevealIfValid(this.tile.x + 1, this.tile.y - 1);
                this.RevealIfValid(this.tile.x + 1, this.tile.y );
                this.RevealIfValid(this.tile.x + 1, this.tile.y + 1);
            }
            

        }
    }

    void RevealIfValid(int x , int y)
    {
        //Validating Valid Revealable Tile By Checking its Boundary Condition that the Revealble tile IS With in the MInField X,y values.
        if(x >= 0 && x < this.mineField.xTotal && y >= 0 && y < this.mineField.yTotal)
        {
            //Calling Reveal Method For this Particular Tile . if It Is With in the MineFiled Size.
            this.mineField.tiles[x, y].clickMechanics.RevealTile();
        }

    }


    //Method To Get The Count Of The Total Available Mines In The Nighbouring Tiles around a Particular Tile
    public int GetAmountNeighbouredMines()
    {

        int mineCounter = 0;

        //Checking all The Eigh Direction Tiles OF The Particular tile That Has Min if yes Then Increase the counter.

        if (this.HasMine(this.tile.x - 1, this.tile.y - 1)) mineCounter++;
        if (this.HasMine(this.tile.x - 1, this.tile.y )) mineCounter++;
        if (this.HasMine(this.tile.x - 1, this.tile.y + 1)) mineCounter++;

        if (this.HasMine(this.tile.x , this.tile.y - 1)) mineCounter++;
        if (this.HasMine(this.tile.x , this.tile.y + 1)) mineCounter++;

        if (this.HasMine(this.tile.x + 1, this.tile.y - 1)) mineCounter++;
        if (this.HasMine(this.tile.x + 1, this.tile.y )) mineCounter++;
        if (this.HasMine(this.tile.x + 1, this.tile.y + 1)) mineCounter++;

        return mineCounter;
    }



    //Method To Check The Partivular Tile IS a Mine.
    bool HasMine(int x, int y)
    {

        bool hasMine = false;

        //validating the Tile Value of x and y should be with in the MineFiled Size.

        if (x >= 0 && x < this.mineField.xTotal && y >= 0 && y < this.mineField.yTotal)
        {
            hasMine = this.mineField.tiles[x, y].isMine;
        }
        return hasMine;
    }
}
