using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixer _mixer;

    private const string _sliderVolumeKey = "SliderVolume";
    private const string _masterMixerParameter = "Master";

    private void Awake() 
    { 
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(_sliderVolumeKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(_sliderVolumeKey);
            _slider.value = Mathf.Pow(10, savedVolume / 20);
            SetVolume(_slider.value);
        }
    } 

    private void SetVolume(float value)
    {
        float setVolume = Mathf.Log10(value) * 20;
        _mixer.SetFloat(_masterMixerParameter, setVolume);

        PlayerPrefs.SetFloat(_sliderVolumeKey, setVolume);
    }
}