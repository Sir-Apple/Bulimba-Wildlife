using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public int TotalTime = 300;//total time (second)
    public Text TimeText;//text of time

    public int minute; //minutes
    public int second; //seconds
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartTime");
    }

    public IEnumerator StartTime()
    {
        while (TotalTime >= 0)
        {
            yield return new WaitForSeconds(1);

            if (TotalTime <= 0)
            {
                //Win
            }

            minute = TotalTime / 60; 
            second = TotalTime % 60;

            if (TotalTime > 60)
            {
                if (second >= 10)
                {
                    TimeText.text = "Time: 0" + minute + ":" + second;
                }
                else if (second < 10)
                {
                    TimeText.text = "Time: 0" + minute + ": " + second;
                }
                
            }
            else if (TotalTime == 60)
            {
                TimeText.text = "Time: 60";
            }
            else if (TotalTime < 60)
            {
                TimeText.text = "Time: " + second;
            }

            TotalTime--;
        }
    }
}
