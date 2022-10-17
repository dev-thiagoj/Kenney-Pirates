using UnityEngine;
using TMPro;

public class GameSessionManager : MonoBehaviour
{
    public float sessionTime;
    [SerializeField] TextMeshProUGUI timeUI;
    [SerializeField] bool isCounting = false;

    [Header("SFX")]
    [SerializeField] SFXManager sfxManager;

    private void Awake()
    {
        if (sfxManager == null) 
            sfxManager = GameObject.Find("=== MANAGERS ===").GetComponentInChildren<SFXManager>();
    }

    private void Start()
    {
        sessionTime *= 60;
        isCounting = true;
    }

    private void Update()
    {
        CountdownTime();
        DisplayTime(sessionTime);
    }

    void CountdownTime()
    {
        if (isCounting)
        {
            if (sessionTime > 0) 
                sessionTime -= Time.deltaTime;

            else
            {
                isCounting = false;
                sessionTime = 0;
                Actions.saveDataInPlayerPrefs.Invoke();
                sfxManager.PlayMusicbyType(MusicType.LEVEL_WIN);
            }
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
