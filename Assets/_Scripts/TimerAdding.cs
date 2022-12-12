using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerAdding : MonoBehaviour
{
    public float timerCounter;
    private bool isTimerActive;

    [SerializeField] private TMP_Text timerText;
    private float timer;

    private void Update()
    {
        Counter();
    }

    private void Counter()
    {

        if (timerCounter < 0)
        {
            timerCounter = 0;
            isTimerActive = false;
        }
        timerCounter += Time.deltaTime;

        DisplayTime(timerCounter);
    }

    private void DisplayTime(float timeToDisplay)
    {


        float hours = Mathf.FloorToInt(timeToDisplay / 3600) % 24;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60) % 60;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //float miliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
