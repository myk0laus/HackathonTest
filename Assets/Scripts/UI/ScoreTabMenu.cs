using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTabMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Image _medalImage;
    [SerializeField] private Sprite _medalSprite; 
    [SerializeField] private Sprite _noMedalSprite;  
    private const string BestScore = "BestScore"; 
    private int _score = 0;

    private void OnEnable()
    { 
        _score = PlayerPrefs.GetInt(BestScore);
        UpdateScoreTab(_score);
    }
     
    private void UpdateScoreTab(int score)
    {
        if (score < 1) 
        {
            _medalImage.sprite = _noMedalSprite;
            _medalImage.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);
            _scoreText.text = $"No best score";
        }
        else
        {
            _medalImage.sprite = _medalSprite;
            _medalImage.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 130);        
            _scoreText.text = $"Best score: {score}"; 
        }
    }
}