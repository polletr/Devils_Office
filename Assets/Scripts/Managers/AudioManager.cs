using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Souce")]
    [SerializeField]
    private AudioSource MusicSpeaker;
    [SerializeField]
    private AudioSource SFXSpeaker;
    [SerializeField]
    private AudioSource ExtraSpeaker;
    [SerializeField]
    private AudioSource UISpeaker;

    [Header("Audio Mixer")]
    [SerializeField, Tooltip("Audio Mixer form the Assets folder")]
    private AudioMixer _MasterAudioMixer;

    [Header("Audio Clip Container")]
    public AudioClipContainer _audioClip;

    public void Play(AudioClip clip, AudioSource speaker)
    {
        if (clip != null)
        {
            speaker.clip = clip;
            speaker.Play();
        }
        else Debug.LogWarning("Audio Clip is null");
    }
    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            MusicSpeaker.loop = true;
            MusicSpeaker.clip = clip;
            MusicSpeaker.Play();
        }
        else Debug.LogWarning("Audio Clip is null");
    }
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            SFXSpeaker.clip = clip;
            SFXSpeaker.Play();
        }
        else Debug.LogWarning("Audio Clip is null");
    }
    public void PlayUI(AudioClip clip)
    {
        if (clip != null)
        {
            UISpeaker.clip = clip;
            UISpeaker.Play();
        }
        else Debug.LogWarning("Audio Clip is null");
    }
    public void PlayCountDown()
    {
        if (_audioClip.CountDown != null)
        {
            SFXSpeaker.clip = _audioClip.CountDown;
            SFXSpeaker.Play();
        }
        else Debug.LogWarning("Audio Clip is null");
    }
    public void PlayRandomSfx(AudioClip a)
    {
        if (a != null)
        {
            ExtraSpeaker.PlayOneShot(a);
        }
        else Debug.LogWarning("Audio Clip is null");
    }
    public void StopAllSounds()
    {
        MusicSpeaker.Stop();
        SFXSpeaker.Stop();
        UISpeaker.Stop();
        ExtraSpeaker.Stop();
    }
}
