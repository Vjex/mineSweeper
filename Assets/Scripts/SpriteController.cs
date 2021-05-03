using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{ 

    //NOTE *** : Sprite is a Unity Inbuilt Class that is Used to handle and hold diffrent 2D game Objects.

    //var that hold the Default Sprite i.e : the Tile Here.
    public Sprite defaultSprite;

    //var that hold the mine Sprite i.e : mine Tile here.
    public Sprite mineSprite;

    //var that hold the secureTile Sprite i.e : Secured Tile Here.
    public Sprite securedTileSprite;

    //var that hold the DeadlyMine  Sprite i.e : TheDeadlyMine Tile Here.
    public Sprite deadlyMineSprite;

    //var that hold the Default Sprite i.e : Secured Mine Tile Here.
    public Sprite securedMineSprite;

    //var that hold the Blanks Tile Sprite i.e : 0,8 Tiles.
    public Sprite[] emptyTileSprites;




  

    public void SetEmptyTileSprite(int amountNeighbouredMines)
    {

        //amountNeighbouredMines ==> this Hold the Index Value Of Empty/Blank tile from 0,8 From Which need To Replace that Tile.

        //Now Replacing the Tile Through SpriteRendered Class by the EmptySprite of the Passed Index.
        GetComponent<SpriteRenderer>().sprite = emptyTileSprites[amountNeighbouredMines];


        //Now Also Disbaling Click (2D Box Collider) So that User Can Not Click on that tile Again.

        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetMineSprite()
    {

        //amountNeighbouredMines ==> this Hold the Index Value Of Empty/Blank tile from 0,8 From Which need To Replace that Tile.

        //Now Replacing the Tile Through SpriteRendered Class by the EmptySprite of the Passed Index.
        GetComponent<SpriteRenderer>().sprite = mineSprite;


        //Now Also Disbaling Click (2D Box Collider) So that User Can Not Click on that tile Again.

        GetComponent<BoxCollider2D>().enabled = false;
    }


    public void SetSecuredTileSprite()
    {

        //amountNeighbouredMines ==> this Hold the Index Value Of Empty/Blank tile from 0,8 From Which need To Replace that Tile.

        //Now Replacing the Tile Through SpriteRendered Class by the EmptySprite of the Passed Index.
        GetComponent<SpriteRenderer>().sprite = securedTileSprite;


        //here We Will Not Deactivate the Click As This Sprite Will be Used By the User To Flag the Tile as He / She thinks That it might be a Bomb/mine.
    }

    public void SetDeadlyMineSprite()
    {

        //amountNeighbouredMines ==> this Hold the Index Value Of Empty/Blank tile from 0,8 From Which need To Replace that Tile.

        //Now Replacing the Tile Through SpriteRendered Class by the EmptySprite of the Passed Index.
        GetComponent<SpriteRenderer>().sprite = deadlyMineSprite;


        //Now Also Disbaling Click (2D Box Collider) So that User Can Not Click on that tile Again.

        GetComponent<BoxCollider2D>().enabled = false;
    }


    public void SetSecuredMineSprite()
    {

        //amountNeighbouredMines ==> this Hold the Index Value Of Empty/Blank tile from 0,8 From Which need To Replace that Tile.

        //Now Replacing the Tile Through SpriteRendered Class by the EmptySprite of the Passed Index.
        GetComponent<SpriteRenderer>().sprite = securedMineSprite;


        //Now Also Disbaling Click (2D Box Collider) So that User Can Not Click on that tile Again.

        GetComponent<BoxCollider2D>().enabled = false;
    }


    public void SetDefaultTileSprite()
    {

        //amountNeighbouredMines ==> this Hold the Index Value Of Empty/Blank tile from 0,8 From Which need To Replace that Tile.

        //Now Replacing the Tile Through SpriteRendered Class by the EmptySprite of the Passed Index.
        GetComponent<SpriteRenderer>().sprite = defaultSprite;

        //here We Will Not Deactivate the Click Asthis is the Dafault blue Tile That need to be Clicked By The User.



    }


}
