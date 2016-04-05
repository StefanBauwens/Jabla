using UnityEngine;
using System.Collections;
using UnityEngine.UI; //gives access to Text in UI

public class Timer : MonoBehaviour
{

    public Text textTimer;
    public float timeInMinutes;
    public static float changeTime;  //make static so it will be accessible in other Classes
    float countdownTime;
    public TimeMenu timeScreen;

    
    void Start()
    {
        countdownTime = (timeInMinutes * 60);   //change minutes to seconds
    }
    // Update is called once per frame
    void Update()
    {
        countdownTime -= Time.deltaTime;
        
        countdownTime += changeTime/360f;
        //Math.FloorToInt --> number will be rounded down to the nearest integer(afronden)
        int minutes = Mathf.FloorToInt(countdownTime / 60f);    
        int seconds = Mathf.FloorToInt(countdownTime - minutes * 60);
        
        //display mm:ss format on screen
        string displayTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        textTimer.text = displayTime;

        //changeTime = timeInMinutes;
        
        if (minutes == 0 && seconds == 0)
        {
            timeScreen.timeUp = true; // time is up
            timeScreen.TimeUp(); // calls method TimeUp from class TimeMenu
        }
        
        //Debug.Log(countdownTime);
        
    }
}
