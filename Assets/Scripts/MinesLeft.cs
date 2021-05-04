using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinesLeft : MonoBehaviour
{
    //Minefield Script var assigned To Minefiled Object.
    MineField mineField;

    //Text Var For The Mine Left text At The Top Bar UI that Will be Assigned Direct to UI Level To This Script.

    public Text mineLeftText;


    private void Start()
    {
        //Initialising Minefield Script.

        this.mineField = GameObject.FindGameObjectWithTag("Minefield").GetComponent<MineField>();
    }



    //Now Changing The Mines Left Text 
    private void FixedUpdate()
    {
        this.mineLeftText.text = this.mineField.minesLeft.ToString();
    }
}
