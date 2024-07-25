public class SoundEffectsButton : SoundChangerButton
{
    private const string _soundEffectsKey = "SoundEffects";
    private const string _effectsMixerParameter = "Effects";

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
            Mixer.SetFloat(_effectsMixerParameter, -80);
        }
        else
        {
            IconImage.sprite = EnabledSprite;
            Mixer.SetFloat(_effectsMixerParameter, 0);
        }
    }
}