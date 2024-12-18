public class VolumeButton : SoundChangerButton
{

    private const string _soundEffectsKey = "SoundsMusic";
    private const string _musicMixerParameter = "Music"; 
     
    private void Awake() 
    {
        PlayerPrefsKey = _soundEffectsKey;
    } 
    protected override void OnButtonClick()
    {
        Enabled = !Enabled;
        UpdateVisual();
        SaveState();
    }

    protected override void UpdateVisual()
    {
        if (Enabled)
        {
            IconImage.sprite = DisabledSprite;
            Mixer.SetFloat(_musicMixerParameter, -80);
        }
        else
        {
            IconImage.sprite = EnabledSprite;
            Mixer.SetFloat(_musicMixerParameter, 0);
        }
    }
}