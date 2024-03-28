using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private float timer = 80f;
   
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField]
   public Transform[] spawnPoints;

    public int taskPoints;

    public int killPoints;

    private void Awake()
    {
       // timerText.gameObject.SetActive(false);
    }

    void Update()
    {
        TimerCount();
        RankPlayers();
    }

    private void TimerCount()
    {
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        //int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
        if (timerText != null && timer < 21f)
        {
           // timerText.gameObject.SetActive(true);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); // + ":" + milliseconds.ToString("00");   
        }
        if (timer <= 0)
        {
            EndGame();
        }
    }

    private void RankPlayers()
    {   

    }

    public void EndGame()
    {
        SceneManager.LoadScene("03_LoseScreen");
    }



}