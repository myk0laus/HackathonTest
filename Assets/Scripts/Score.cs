using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _score;

    public int ScoreProp => _score; 

    public void IncreaseScore()
    {
        _score++;
        UpdateUi(_score);
    }

    private void UpdateUi(int score) 
    {
        _scoreText.text = "Passed obstacles: " + score;
    }
}