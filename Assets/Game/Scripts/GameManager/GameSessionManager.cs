using UnityEngine;
using TMPro;

public class GameSessionManager : MonoBehaviour
{
    public float sessionTime;
    [SerializeField] TextMeshProUGUI timeUI;
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
            Actions.saveDataInPlayerPrefs.Invoke();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0) timeToDisplay = 0;
        else if (timeToDisplay > 0) timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
