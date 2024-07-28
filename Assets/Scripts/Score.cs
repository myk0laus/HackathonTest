using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _score;
    private const string BestScore = "BestScore";

    public int ScoreProp => _score;

    public void IncreaseScore()
    {
        _score++;
        UpdateUi(_score);
        UpdateScorePrefs(_score);
    }

    private void UpdateUi(int score)
    {
        _scoreText.text = "Passed obstacles: " + score;
    }

    private void UpdateScorePrefs(int score)
    {
        if (PlayerPrefs.GetInt(BestScore) < score)
        {
            PlayerPrefs.SetInt(BestScore, _score);
        }
    }
}