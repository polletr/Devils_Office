using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : Menu
{
    protected override void Awake()
    {
        AudioManager.Instance.StopAllSounds();
        AudioManager.Instance.PlayMusic(AudioManager.Instance._audioClip.FinishScreen);

    }

    public void OnRestartGame()
    {
        AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.ButtonClick);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void OnBackToMenu()
    {
        SceneManager.LoadScene(0);
        AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.ButtonClick);

    }

}
