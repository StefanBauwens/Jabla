using UnityEngine;
using System.Collections;
using UnityEngine.UI; //gives access to Text in UI

public class Timer : MonoBehaviour
{

    public Text textTimer;
    public float timeInMinutes;
    float countdownTime;


    void Start()
    {
        countdownTime = (timeInMinutes * 60);   //change minutes to seconds
    }
    // Update is called once per frame
    void Update()
    {
        countdownTime -= Time.deltaTime;

        //Math.FloorToInt --> number will be rounded down to the nearest integer(afronden)
        int minutes = Mathf.FloorToInt(countdownTime / 60f);    
        int seconds = Mathf.FloorToInt(countdownTime - minutes * 60);

        //display mm:ss format on screen
        string displayTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        textTimer.text = displayTime; 
        
    }
}
