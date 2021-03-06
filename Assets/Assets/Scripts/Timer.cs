﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; //gives access to Text in UI

public class Timer : MonoBehaviour
{

    public Text textTimer;
    public float timeInMinutes;
    public static float changeTime;  //make static so it will be accessible in other Classes
    protected float countdownTime;
    //public TimeMenu timeScreen;
	public GameObject timeMenuCanvas;

	public int minutes;
	public int seconds;

    
    void Start()
    {
        countdownTime = (timeInMinutes * 60);   //change minutes to seconds
    }
    // Update is called once per frame
    void Update()
    {
        countdownTime -= Time.deltaTime;
        
        countdownTime += changeTime/360f; //If you take timepotion then the time goes faster down
        //Math.FloorToInt --> number will be rounded down to the nearest integer(afronden)
        minutes = Mathf.FloorToInt(countdownTime / 60f);    
        seconds = Mathf.FloorToInt(countdownTime - minutes * 60);
        
        //display mm:ss format on screen
        string displayTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        textTimer.text = displayTime;
		        
        if (minutes == 0 && seconds == 0)
        {
			timeMenuCanvas.SetActive(true);
            /*timeScreen.timeUp = true; // time is up
            timeScreen.TimeUp(); // calls method TimeUp from class TimeMenu*/
        }        
    }
}
