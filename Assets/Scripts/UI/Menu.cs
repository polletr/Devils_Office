using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    protected bool _startActive;

    [Header("Menu Game Objects")]
    [SerializeField]
    protected GameObject _currentMenu;
    [SerializeField]
    private GameObject _creditsMenu;
    [SerializeField]
    private GameObject _controlsMenu;
    [SerializeField]
    private GameObject _settingMenu;


    protected bool isMusted;

    protected virtual void Awake()
    {
        DisableScreens();
    }

    //Screen Management
    protected virtual void DisableScreens()
    {
        _currentMenu?.SetActive(_startActive);
        _creditsMenu?.SetActive(false);
        _controlsMenu?.SetActive(false);
        //if (_settingMenu
        _settingMenu?.SetActive(false);
    }

    //Menu Management

    public void OnToggleCurrentMenu()
    {
        _currentMenu.SetActive(!_currentMenu.activeSelf);
        AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.ButtonClick);
    }
    public void OnToggleCredits()
    {
        _creditsMenu.SetActive(!_creditsMenu.activeSelf);
        AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.ButtonClick); 
    }

    public void OnToggleControls()
    {
        _controlsMenu.SetActive(!_controlsMenu.activeSelf);
        AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.ButtonClick);
    }

    public void OnToggleSettings()
    {
        _settingMenu.SetActive(!_settingMenu.activeSelf);
        AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.ButtonClick);
    }

    public void OnQuitGame()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
            CloseTab();
#else
            Application.Quit();
#endif
    }

}
