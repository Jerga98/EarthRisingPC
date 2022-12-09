using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerAdding : MonoBehaviour
{
    public TMP_Text clockUI;
    public float timeCount = 0;
    [Header("Do koliko minuta igraè može igrati, ako je limit 0 onda ide u beskonaèno")]
    public int limit;
    public float timerCounter;
    private bool isTimerActive;

    private void Start()
    {
        limit *= 60;
    }

    private void Update()
    {
        void Counter()
        {

            if (timerCounter < 0)
            {
                timerCounter = 0;
                isTimerActive = false;
            }
            timerCounter += Time.deltaTime;
        }

        timeCount += Time.deltaTime;
        if (limit == 0)
        {
            //Dijelimo sa cijelim brojem 60 da dobijemo minute
            int minutes = (int)timeCount / 60;
            int hours = 0;
            
            //Djelimo sa 60 da dobijemo ostatak za sekunde
            //int seconds = (int)allTime % 60;
            int seconds = Mathf.FloorToInt(timeCount % 60);

            if(minutes == 60)
            {
                minutes = 0;
                hours += 1;
            }

            //ako je manje od 10 za minute i sekunde //2:4
            if (hours < 10 && minutes < 10 && seconds < 10)
            {
                clockUI.text = "0" + hours + ":" + "0" + minutes + ":" + "0" + seconds; //02:04
            }

            else if (hours < 10 && minutes < 10 && seconds < 10)
            {
                clockUI.text = "0" + hours + ":" + "0" + minutes + ":" + "0" + seconds; //02:04
            }

            //Ako su minute jednoznamenkaste, a sekunde dvoznamenkaste //4:19
            else if (hours < 10 && minutes < 10 && seconds >= 10)
            {
                clockUI.text = "0" + hours + ":" + "0" + minutes + ":" + seconds; //04:19
            }

            //Ako su minute dvoznamenkaste, a sekunde jednoznamenkaste
            else if (hours < 10 && minutes >= 10 && seconds < 10)
            {
                clockUI.text = "0" + hours + ":" + minutes + ":" + "0" + seconds;
            }

            //Minute i sekunde su dvoznamenkaste
            else
            {
                clockUI.text = "0" + hours + ":" + minutes + ":" + seconds;
            }


        }

        if (timeCount <= limit)
        {
            //Dijelimo sa cijelim brojem 60 da dobijemo minute
            int minutes = (int)timeCount / 60;
            //Djelimo sa 60 da dobijemo ostatak za sekunde
            //int seconds = (int)allTime % 60;
            int seconds = Mathf.FloorToInt(timeCount % 60);

            //ako je manje od 10 za minute i sekunde //2:4
            if (minutes < 10 && seconds < 10)
            {
                clockUI.text = "0" + minutes + ":" + "0" + seconds; //02:04
            }

            //Ako su minute jednoznamenkaste, a sekunde dvoznamenkaste //4:19
            else if (minutes < 10 && seconds >= 10)
            {
                clockUI.text = "0" + minutes + ":" + seconds; //04:19
            }

            //Ako su minute dvoznamenkaste, a sekunde jednoznamenkaste
            else if (minutes >= 10 && seconds < 10)
            {
                clockUI.text = minutes + ":" + "0" + seconds;
            }

            //Minute i sekunde su dvoznamenkaste
            else
            {
                clockUI.text = minutes + ":" + seconds;
            }

        }
    }
}
