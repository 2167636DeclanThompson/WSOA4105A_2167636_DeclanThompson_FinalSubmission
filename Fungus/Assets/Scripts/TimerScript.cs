using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn;

    public Text timerText;
    public GameObject nightText;
    public Text dayText;


    private void Awake()
    {
        TimerOn = true;
        nightText.SetActive(false);
    }

    private void Update()
    {
        if (TimerOn == true)
        {
            if (TimeLeft < 1440)
            {
                TimeLeft += Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else
            {
                TimerOn = false;
                TimeLeft = 0;
                UpdateTimer(TimeLeft);
                dayText.text = "Saturday";                
            }
        }

        if (TimeLeft > 1430)
        {
            timerText.color = Color.red;
        }
               


    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{00:00} : {1:00}", minutes, seconds);
    }
}
