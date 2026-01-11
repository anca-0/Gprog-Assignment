using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;

    void Start()
    {
        int finalScore = 0;
        if (ScoreManager.instance != null)
            finalScore = ScoreManager.instance.GetScore();
        else
            finalScore = PlayerPrefs.GetInt("LastScore", 0); 
        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + finalScore;
    }

}
