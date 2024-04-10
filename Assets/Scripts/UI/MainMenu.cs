using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{
    [SerializeField]
    private GameObject _SettingMenu;

    protected override void Awake()
    {
        _startActive = true;
        DisableScreens();
        AudioManager.Instance.PlayMusic(AudioManager.Instance._audioClip.FinishScreen);
    }

    public void OnToggleSettingMenu() => _SettingMenu.SetActive(!_SettingMenu.activeSelf);

    protected override void DisableScreens()
    {
        base.DisableScreens();
        _SettingMenu?.SetActive(false);
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}