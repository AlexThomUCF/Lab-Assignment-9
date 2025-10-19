using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour, IScoreObserver
{
    public TMP_Text scoreText;  // Use TMP_Text instead of Text

    void Start()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddObserver(this);
        }
    }

    public void OnScoreChanged(int newScore)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + newScore;
    }
}

