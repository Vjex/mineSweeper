using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBar : MonoBehaviour
{
    private MineField mineField;

    private void Start()
    {
        //GetComponent the MinFiled Script To access the Var Of It to Change Size nad Postion of Top Bar According to Minefield Position.

        this.mineField = GameObject.FindGameObjectWithTag("Minefield").GetComponent<MineField>();
    }


    //We calling Fixed Update As We Do not want To Recreate/Chaneg TopBar Size in Every Frame So Only When It Need.
    private void FixedUpdate()
    {

        /////*** Change The Postion Of the Top Bar
        //We Are Diviing By 2f because We Want to Callculate The Distance form Midle Of Minefiled Ttat will e The (0,0) postion Otherwise The Calculation Will be Wrong in terms to get The Correct position.
        // And Subtracting with 1f to get the Correct y Postion.
       //Y is Positive to get / move to Upward direction the top Bar.
        //Added Extra 2f for getting correct Postion
        this.transform.position = new Vector2(0, ((mineField.yTotal - 1f) / 2f + 2f));


        ////Change The Size Of Top Bar.
        ///
        //Just Casting our Top Bar Default Provided transform to RectTransaform var So That We Can Create/ change our Bar Size in Rectangular format as we know Our Bar Will Always be in Rectangular Form.
        RectTransform rectTransform = (RectTransform)this.transform;


        //Change Width Of Bar Dynamically Depending on the Size of Minefield.

        //Changing x Dynamically for Width and y i.e height always fixed to 3 here.
        //Adding Extra more 3 to liitle expand the with to the sie of MineField width.
        rectTransform.sizeDelta = new Vector2(this.mineField.xTotal + 3, 3);
    }
}
