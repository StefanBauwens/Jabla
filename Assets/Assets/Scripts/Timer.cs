using UnityEngine;
using System.Collections;
using UnityEngine.UI; //gives access to Text in UI

public class Timer : MonoBehaviour
{

    public Text textTimer;
    public float countdownTime;
    

    // Update is called once per frame
    void Update()
    {
        countdownTime -= Time.deltaTime; //countdown
        int minutes = Mathf.FloorToInt(countdownTime / 60f);//Math.FloorToInt --> number will be rounded down to the nearest integer(afronden)
        int seconds = Mathf.FloorToInt(countdownTime - minutes * 60);
        string displayTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        textTimer.text = displayTime;//let Text Object display in time format
        
    }
}
