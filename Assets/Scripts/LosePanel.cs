using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private CollisionHandler _vehicle;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Score _score;

    private const float _delay = 1f;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        _playAgainButton.onClick.AddListener(OnPlayButton);
        _mainMenuButton.onClick.AddListener(OnMainMunuButton);
        _quitButton.onClick.AddListener(OnQuitButton);
        _vehicle.Dead += OnPlayerDead;
    }

    private void OnDisable()
    {
        _playAgainButton.onClick.RemoveListener(OnPlayButton);
        _mainMenuButton.onClick.RemoveListener(OnMainMunuButton);
        _quitButton.onClick.RemoveListener(OnQuitButton);
        _vehicle.Dead -= OnPlayerDead;
    }

    private void DisableCanvasGroup()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    private void EnableCanvasGroup()
    {
        Time.timeScale = 0f;
        _canvasGroup.alpha = 1f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        _scoreText.text = "Your score is: " + _score.ScoreProp;
    }

    private void OnPlayerDead()
    {
        Invoke(nameof(EnableCanvasGroup), _delay);
    }

    private void OnPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnMainMunuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    private void OnQuitButton()
    {
        Application.Quit();
    }
}