using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GameSessionManager : MonoBehaviour
{
    [SerializeField] float sessionTime = 5;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] bool isCounting = true;

    private void Start()
    {
        sessionTime *= 60;
    }

    private void Update()
    {
        if (isCounting) CountdownTime();
        DisplayTime(sessionTime);
    }

    void CountdownTime()
    {
        if (sessionTime > 0) sessionTime -= Time.deltaTime;
        else
        {
            sessionTime = 0;
            //TODO Endgame call
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0) timeToDisplay = 0;
        else if (timeToDisplay > 0) timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
