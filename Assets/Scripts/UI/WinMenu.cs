using UnityEngine.SceneManagement;

public class WinMenu : Menu
{
    protected override void Awake() { }

    public void OnRestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnBackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
