using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    //var for Position of the Tile
    public int x;
    public int y;

    //var for Particular Tile Details.
    public bool isMine = false;
    public bool isRevealed = false;
    public bool isSecured = false;


    //Var For Click Mechanics Script .
    public ClickMechanics clickMechanics;


    //var Of Sprite Controller Inbuilt Unity Class to Change The Sprite of Tile After Winning and Loosing the Game For Revealing all The Mines In Teh Game.
    public SpriteController spriteController;

    // Start is called before the first frame update
    void Start()
    {

        //Initializing ClickMechanicsScript;

        this.clickMechanics = this.GetComponent<ClickMechanics>();
        //Initializing SpriteController for This Tile;
        this.spriteController = this.GetComponent<SpriteController>();

    }


    public static Tile CreateNewTile(int x , int y)
    {
        
        //Create a Instance of The Tile Prefab by Loding from Inside Resource folder under prefab folder.
        //Note * : To Use Resources.Load in unity there Sholud be a resources folder under Assets Only Where  It will Search For.
        GameObject tile = (GameObject)Instantiate(Resources.Load("Prefabs/Tile"));

        // Get The Tiles (gameObject (Empty /Main Folder Which Will Contain all The Dynamic Tiles Created .))

        GameObject tiles = GameObject.FindGameObjectWithTag("Tiles");


        //Get The MoinEfield GameObject MineFiled Script Object to acceess Some Var of it.

        MineField mineField = GameObject.FindGameObjectWithTag("Minefield").GetComponent<MineField>(); 


        //  Set the x , y var of Tile Script for its Postion in Minefield.
        //Get Component<Tile> Will Give refrence to the Tile Class Where X and y are The Two Public Varibles Defined in This Class.
        tile.GetComponent<Tile>().x = x;
        tile.GetComponent<Tile>().y = y;

        //Setting Tiles a Parent of This Tile.

        tile.transform.parent = tiles.transform;


        //Now Set Postion of Tile Within The Mine Filed
        //This Formula for Getting the New MineField Postion For Every Tile Is created .(VIDDDDDEO).
        //We Are Diviing By 2f because We Want to Callculate The Distance form Midle Of Minefiled Ttat will e The (0,0) postion Otherwise The Calculation Will be Wrong in terms to get The Correct position.
        // And Subtracting with 1f to change the Postion othwersize will be Postion over one Anothr all the Tiles.
        tile.transform.position = new Vector2((float)x- ((float)mineField.xTotal - 1f )/2f , (float)y - ((float)mineField.yTotal  - 1f)/2f);

        return tile.GetComponent<Tile>();


    }
}
