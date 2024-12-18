using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public abstract class SoundChangerButton : MonoBehaviour
{
    [SerializeField] protected Button ChangerButton;
    [SerializeField] protected Sprite EnabledSprite;
    [SerializeField] protected Sprite DisabledSprite;
    [SerializeField] protected AudioMixer Mixer; 
    [SerializeField] protected Image IconImage;

    protected bool Enabled = true;

    protected string PlayerPrefsKey;

    private void OnEnable()
    {
        ChangerButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        ChangerButton.onClick.RemoveListener(OnButtonClick);
    }

    private void Start()
    {
        LoadState();
    }

    protected void SaveState()
    {
        PlayerPrefs.SetInt(PlayerPrefsKey, Enabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    protected void LoadState()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKey))
        {
            int state = PlayerPrefs.GetInt(PlayerPrefsKey);
            Enabled = state == 1;
            UpdateVisual();
        }
    }
    protected abstract void OnButtonClick();
    protected abstract void UpdateVisual();
}