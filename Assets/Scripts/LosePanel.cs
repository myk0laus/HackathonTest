using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private CollisionHandler _vehicle;
    [SerializeField] private CanvasGroup _losePanelCanvasGroup;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _mainMenuButton; 
    [SerializeField] private Button _quitButton; 
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Score _score;
    [SerializeField] private AudioSource _audioSource; 
    [SerializeField] private AudioClip _loseClip;

    private const float _delay = 1f;
     
    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        _playAgainButton.onClick.AddListener(OnPlayButton);
        _mainMenuButton.onClick.AddListener(OnMainMenuButton);
        _quitButton.onClick.AddListener(OnQuitButton);
        _vehicle.Dead += OnPlayerDead;
    }

    private void OnDisable()
    {
        _playAgainButton.onClick.RemoveListener(OnPlayButton);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButton);
        _quitButton.onClick.RemoveListener(OnQuitButton);
        _vehicle.Dead -= OnPlayerDead;
    }

    private void DisableCanvasGroup()
    {
        _losePanelCanvasGroup.alpha = 0f;
        _losePanelCanvasGroup.interactable = false;
        _losePanelCanvasGroup.blocksRaycasts = false;
    }

    private void EnableCanvasGroup()
    {
        Time.timeScale = 0f;
        _losePanelCanvasGroup.alpha = 1f;
        _losePanelCanvasGroup.interactable = true;
        _losePanelCanvasGroup.blocksRaycasts = true;
        _scoreText.text = "Your score is: " + _score.ScoreProp;
    }

    private void OnPlayerDead()
    {
        _pauseButton.interactable = false;
        Music.Instance.PauseMusic();
        if (!_audioSource.isPlaying)       
            _audioSource.PlayOneShot(_loseClip);
    
        Invoke(nameof(EnableCanvasGroup), _delay);
    }

    private void OnPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Music.Instance.SetGameCLip();
    }

    private void OnMainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Music.Instance.SetMenuCLip();
    }

    private void OnQuitButton()
    {
        Application.Quit();
    }
}