using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _gameMusic;

    public static Music Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(this);

        _audioSource.clip = _menuMusic;
        _audioSource.Play();
    }

    public void SetMenuCLip()
    {
        if (_audioSource.clip != _menuMusic)
        {
            _audioSource.clip = _menuMusic;
            _audioSource.Play();
        }
        ResumeMusic();
    }

    public void SetGameCLip()
    {
        if (_audioSource.clip != _gameMusic)
        {
            _audioSource.clip = _gameMusic;
            _audioSource.Play();
        }
        ResumeMusic();
    }

    public void PauseMusic() 
    {
        _audioSource.Pause();
    }

    public void ResumeMusic()
    {
        _audioSource.UnPause();
    }
}