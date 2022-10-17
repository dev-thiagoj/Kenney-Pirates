using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    [Header("Used in Gameplay")]
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] int score;
    [SerializeField] Transform confirmationBox;

    [Header("Used in EndGame")]
    public int finalScore;
    [SerializeField] TextMeshProUGUI finalScoreDisplay;

    [Header("Player Reference")]
    [SerializeField] GunBase playerGunBase;

    #region Actions
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
    #endregion

    private void Awake()
    {
        if (GameObject.Find("=== PLAYER ==="))
        {
            playerGunBase = GameObject.Find("=== PLAYER ===").GetComponent<GunBase>();
        }
    }

    private void Start()
    {
        score = 0;

        if (finalScoreDisplay != null)
            finalScoreDisplay.text = "Total score: " + finalScore.ToString();

        DisplayScore();
    }

    void AddPoint()
    {
        if (playerGunBase != null)
        {
            if (playerGunBase.health.isAlive)
            {
                score++;
                DisplayScore();
            }
        }
    }

    void DisplayScore()
    {
        scoreUI.text = "Score: " + score.ToString();
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("PlayerFinalScore", score);
        StartCoroutine(ConfirmationBoxCoroutine());
    }

    IEnumerator ConfirmationBoxCoroutine()
    {
        confirmationBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationBox.gameObject.SetActive(false);
    }
}
