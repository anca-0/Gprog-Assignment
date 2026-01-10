using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreText;
   
    private int score = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
    public int GetScore()
    {
        return score;
    }

   
}
