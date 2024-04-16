using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{

    protected override void Awake()
    {
        _startActive = true;
        DisableScreens();
        AudioManager.Instance.PlayMusic(AudioManager.Instance._audioClip.FinishScreen);
    }
    
    protected override void DisableScreens()
    {
        base.DisableScreens();
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}