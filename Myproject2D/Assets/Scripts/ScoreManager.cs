using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int scores;
    public static int Best_Score;
    [SerializeField] private TMPro.TextMeshProUGUI ScoreText;
    [SerializeField]  TMPro.TextMeshProUGUI BestScore;

    void Start()
    {
        scores = 0;
        Best_Score = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreText();
        UpdateBestScoreText();
    }

    void Update()
    {
        ScoreText.text = "Score:" + scores; 
    }

    public void OnAddScore()
    {
        scores++;
        UpdateScoreText();

        if (scores > Best_Score)
        {
            Best_Score = scores;
            PlayerPrefs.SetInt("BestScore", Best_Score);
            UpdateBestScoreText();
        }
    }
    private void UpdateScoreText()
    {
        ScoreText.text = "Score: " + scores;
    }

    private void UpdateBestScoreText()
    {
        BestScore.text = "Best Score: " + Best_Score;
    }

    void OnDestroy()
    {
        Best_Score =  PlayerPrefs.GetInt("Score");
        Best_Score.ToString();
    }
}
