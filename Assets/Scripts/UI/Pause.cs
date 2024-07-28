using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private CanvasGroup _pauseMenuCanvasGroup;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Image _pauseButtonImage;
    [SerializeField] private Sprite _pauseSprite;
    private Sprite _resumeSprite; 
     
    private bool _paused;

    private void Awake()
    {
        _resumeSprite = _pauseButtonImage.sprite;
    }

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        _mainMenuButton.onClick.AddListener(OnMainMenuButton);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClicked);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButton);
    }

    private void OnPauseButtonClicked()
    {
        _paused = !_paused; 

        if (_paused)       
            PauseGame(); 
        else      
            ResumeGame();
        
    }

    private void PauseGame()
    {
        _pauseButtonImage.sprite = _pauseSprite;
        ActivateCanvasGroup();
        Time.timeScale = 0f;
    }    
    
    private void ResumeGame()
    {
        _pauseButtonImage.sprite = _resumeSprite;
        DeactivateCanvasGroup();
        Time.timeScale = 1.0f;
    }

    private void ActivateCanvasGroup()
    {
        _pauseMenuCanvasGroup.alpha = 1.0f;
        _pauseMenuCanvasGroup.blocksRaycasts = true;
        _pauseMenuCanvasGroup.interactable = true;
    }

    public void DeactivateCanvasGroup()
    {
        _pauseMenuCanvasGroup.alpha = 0f;
        _pauseMenuCanvasGroup.blocksRaycasts = false;
        _pauseMenuCanvasGroup.interactable = false;
    }

    private void OnMainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Music.Instance.SetMenuCLip();
    }
}