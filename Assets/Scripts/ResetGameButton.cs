using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGameButton : MonoBehaviour
{
    public Sprite HappyFace;
    public Sprite NeutralFace;
    public Sprite SadFace;


    public Button resetButton;


   public void SetHappy()
    {
        this.resetButton.image.sprite = this.HappyFace;
    }

    public void SetNeutral()
    {
        this.resetButton.image.sprite = this.NeutralFace;
    }

    public void SetSad()
    {
        this.resetButton.image.sprite = this.SadFace;
    }
}
