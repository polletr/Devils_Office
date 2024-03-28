using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private float timer = 80f;
   
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField]
    public Transform[] spawnPoints;

    public int taskPoints;

    public int killPoints;

    public List<PlayerController> playersToRank = new();

    private void Awake()
    {
       // timerText.gameObject.SetActive(false);
    }

    void Update()
    {
        TimerCount();
        if (playersToRank.Count > 0)
        {
            RankPlayers(playersToRank);
        }
    }

    private void TimerCount()
    {
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        //int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
        if (timerText != null && timer < 21f)
        {
            timerText.gameObject.SetActive(true);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); // + ":" + milliseconds.ToString("00");   
        }
        if (timer <= 0)
        {
            EndGame();
        }
    }

    public void RankPlayers(List<PlayerController> players)
    {   
        playersToRank = players.OrderByDescending(p => p.points).ThenByDescending(p => p.killCount).ToList();
        //Debug.Log(playersToRank[0].controlScheme.ToString());
        //Debug.Log(playersToRank[1].controlScheme.ToString());

    }

    public void EndGame()
    {
        //Display Victory Screen and show the winner, second, etc.
    }



}