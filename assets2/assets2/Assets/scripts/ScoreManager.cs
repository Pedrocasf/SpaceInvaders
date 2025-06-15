using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private int score = 0;
    private int highscore = 0;

    void Awake()
    {
        if (instance == null) { instance = this; } else { Destroy(gameObject); }
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        score = 0;
        UpdateUI();
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        CheckForHighscore();
        UpdateUI();
    }

    private void CheckForHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
        }
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
}