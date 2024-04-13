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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void OnBackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
