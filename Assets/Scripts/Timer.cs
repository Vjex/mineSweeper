using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Text Variable of Timer In Ther UI That Is Assigned At UI Level To this Script And This Script Is Attached To TimerObject Game Object.

    public Text timerText;


    //Ther Is Special Inbuilt C# Class To get The Timer Related Method i.e stopWach Class.
    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();


    //Method To Reset The Timer
    public void ResetTimer()
    {
        this.stopwatch.Reset();
    }


    //Method To Be Called When A Game Starts From ClickMechanics Script When Player Click First Time On A Tile After The Minefiled Createion Where we Also Set  the Game Started True.
    public void StartTimer()
    {

        //First Reste The Timer Befrore Starting New One.
        this.ResetTimer();

        this.stopwatch.Start();

    }


    public void StopTimer()
    {
        this.stopwatch.Stop();
    }



    //Methpd To Get The Current Time Of Timer Started.

    public int GetCurrentTime()
    {
        return (int)(this.stopwatch.ElapsedMilliseconds/1000f);
    }


    //Change The Timer Text Inside Inbuilt Fixed Uppdate Method

    private void FixedUpdate()
    {
        this.timerText.text = this.GetCurrentTime().ToString();
    }
}
