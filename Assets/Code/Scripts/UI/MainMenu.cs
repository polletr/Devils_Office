using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [Header("SettingsMenu"), SerializeField]
    private GameObject _SettingMenu;
    private GameObject _PlayMenu;

    [Header("Playerelection")]
    [SerializeField]
    private Toggle TwoPlayers;
    [SerializeField]
    private Toggle ThreePlayers;
    [SerializeField]
    private Toggle FourPlayers;

    [Header("StartGameButton")]
    [SerializeField]
    private Button _startGame;

    int playerCount = 2;

    private void Awake()
    {
        //play settings
        TwoPlayers.isOn = true;
       _startGame.interactable = true;


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


    public void CheckSelectedPlayers()
    {
        _startGame.interactable = true;
        if (TwoPlayers.isOn)
        {
            playerCount = 2;
        }
        else if (ThreePlayers.isOn)
        {
            playerCount = 3;
        }
        else if (FourPlayers.isOn)
        {
            playerCount = 4;
        }
        else
        {
            Debug.Log("No Player Selected");
            _startGame.interactable = false;
        }
    }
    public void StartGame()
    {
            switch (playerCount)
            {
                case 2:
                    Load2PlayerGame();
                    break;
                case 3:
                    Load3PlayerGame();
                    break;
                case 4:
                    Load4PlayerGame();
                    break;
            }
    }



    #region LoadGame

    private void Load2PlayerGame()
    {
      Debug.Log("2 Player Game");
    }

    private void Load3PlayerGame()
    {
      Debug.Log("3 Player Game");
    }
    private void Load4PlayerGame()
    {
      Debug.Log("4 Player Game");
    }

    #endregion
}
