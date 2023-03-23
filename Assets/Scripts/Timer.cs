using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    int minutes;
    float seconds;
    public float timePassed;
    public bool keepTime = false;
    TextMeshProUGUI timerText;

    private void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        StartTimer();
    }

    void FixedUpdate()
    {
        if (keepTime)
        {
            timePassed += Time.fixedDeltaTime;

            minutes = Mathf.FloorToInt(timePassed / 60);
            seconds = timePassed % 60;

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StartTimer()
    {
        timePassed = 0;
        keepTime = true;
    }

    public void StopTimer()
    {
        keepTime = false;
    }
}
