using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    [Header("Audio Souce")]
    [SerializeField, Tooltip("Audio Mixer form the Assets folder")]
    private AudioMixer _MasterAudioMixer;

    [Header("Sliders In Settings")]
    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;
    protected override void Awake()
    {
        
    }

    private void SetUpVolumeValues()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
    }
    private void OnEnable()
    {
        SetUpVolumeValues();

        MasterSlider.onValueChanged.AddListener(delegate { SetMasterVolume(); });
        MusicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        SFXSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
    }

    private void OnDisable()
    {
        MasterSlider.onValueChanged.RemoveAllListeners();
        MusicSlider.onValueChanged.RemoveAllListeners();
        SFXSlider.onValueChanged.RemoveAllListeners();
    }

    private void SetMasterVolume()
    {
        if (!isMusted)
            _MasterAudioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
            PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
    }
    private void SetMusicVolume()
    {
        if (!isMusted)
            _MasterAudioMixer.SetFloat("MusicVolume", Mathf.Log10(MusicSlider.value) * 20);
            PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
    }
    private void SetSFXVolume()
    {
        if(!isMusted)
            _MasterAudioMixer.SetFloat("SFXVolume", Mathf.Log10(SFXSlider.value) * 20);
            PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }

    public void OnToggleMute()
    {
        isMusted = !isMusted;
        _MasterAudioMixer.SetFloat("Master", isMusted ? Mathf.Log10(MasterSlider.minValue) * 20 : Mathf.Log10(MasterSlider.maxValue) * 20);
        AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.ButtonClick);


    }

}
