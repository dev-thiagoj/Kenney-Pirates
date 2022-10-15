using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Used in Gameplay")]
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] int score;

    [Header("Used in EndGame")]
    public int finalScore;
    [SerializeField] TextMeshProUGUI finalScoreDisplay;


    private void OnEnable()
    {
        Actions.saveDataInPlayerPrefs += SaveScore;
        Actions.addPlayerPoint += AddPoint;
    }

    private void OnDisable()
    {
        Actions.saveDataInPlayerPrefs -= SaveScore;
        Actions.addPlayerPoint -= AddPoint;
    }

    private void Start()
    {
        score = 0;
        if(finalScoreDisplay != null) finalScoreDisplay.text = finalScore.ToString();

        DisplayScore();
    }

    [NaughtyAttributes.Button]
    void AddPoint()
    {
        score++;
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreUI.text = "Score: " + score.ToString();
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("PlayerFinalScore", score);
    }
}
