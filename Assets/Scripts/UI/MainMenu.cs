using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [SerializeField]
    private GameObject _SettingMenu;
    [SerializeField]
    private GameObject _PlayMenu;

    protected override void Awake()
    {
        //Ui settings
        _startActive = true;
        DisableScreens();
    }

    public void OnToggleSettingMenu() => _SettingMenu.SetActive(!_SettingMenu.activeSelf);
    public void OnTogglePlayMenu() => _PlayMenu.SetActive(!_PlayMenu.activeSelf);

    protected override void DisableScreens()
    {
        base.DisableScreens();
        _SettingMenu?.SetActive(false);
        _PlayMenu?.SetActive(false);
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}