using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UiText : MonoBehaviour
{
    public Text scoreText; // Reference to UI Text component
    public ScoreManager scoreManager; // Reference to ScoreManager

    void Start()
    {
        // Assign the ScoreManager instance if not set in inspector
        if (scoreManager == null)
        {
            scoreManager = ScoreManager.Instance;
        }
    }

    void Update()
    {
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null && scoreManager != null)
        {
            scoreText.text = "Score: " + scoreManager.score.ToString();
        }
    }
}