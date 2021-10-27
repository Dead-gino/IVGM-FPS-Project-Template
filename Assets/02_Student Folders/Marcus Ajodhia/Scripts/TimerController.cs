using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //timeCounter.text = "00:00.00";
        timeCounter.text = "00:00.00";
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            //string timePlayingStr = timePlaying.ToString("mm':'ss'.'ffffff");
            //string timePlayingStr = string.Format("{0:D2}:{1:D2}",timePlaying.Minutes,timePlaying.Seconds);
            int time = Int32.Parse(timePlaying.Hours.ToString());
            string timePlayingStr;
            if (time == 0)
            {
                timePlayingStr = timePlaying.Minutes.ToString() + "." + timePlaying.Seconds.ToString();
            }
            else
            {
                timePlayingStr = timePlaying.Hours.ToString() + ":" +  timePlaying.Minutes.ToString() + "." + timePlaying.Seconds.ToString();
            }
            
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
