using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBar : MonoBehaviour
{
    private MineField mineField;

    private void Start()
    {
        //GetComponent the MinFiled Script To access the Var Of It to Change Size nad Postion of Bottom Bar According to Minefield Position.

        this.mineField = GameObject.FindGameObjectWithTag("Minefield").GetComponent<MineField>();
    }


    //We calling Fixed Update As We Do not want To Recreate/Chaneg BottomBar Size in Every Frame So Only When It Need.
    private void FixedUpdate()
    {   

        /////*** Change The Postion Of the Bottom Bar
        //We Are Diviing By 2f because We Want to Callculate The Distance form Midle Of Minefiled Ttat will e The (0,0) postion Otherwise The Calculation Will be Wrong in terms to get The Correct position.
        // And Subtracting with 1f to get the Correct y Postion.
        //added '-' in y postion to move Down in y dorection for Bottom Bar.
        //Added Extra 2f for getting correct Postion
        this.transform.position = new Vector2(0, -((mineField.yTotal - 1f) / 2f + 2f));


        ////Change The Size Of Bottom Bar.
        ///
        //Just Casting our Bottom Bar Default Provided transform to RectTransaform var So That We Can Create/ change our Bar Size in Rectangular format as we know Our Bar Will Always be in Rectangular Form.
        RectTransform rectTransform = (RectTransform)this.transform;


        //Change Width Of Bar Dynamically Depending on the Size of Minefield.

        //Changing x Dynamically for Width and y i.e height always fixed to 3 here.
        //Adding Extra more 3 to liitle expand the with to the sie of MineField width.
        rectTransform.sizeDelta = new Vector2(this.mineField.xTotal + 3, 3);
    }


    //Method To Quit / Exit The Apllication.

    public void QuitGame()
    {
        Application.Quit();
    }

}
