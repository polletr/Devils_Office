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
    [SerializeField] private TextMeshProUGUI gameStatsText;

    [SerializeField]
    public Transform[] spawnPoints;

    public int taskPoints;

    public int killPoints;

    public List<PlayerController> playersToRank = new();

    [SerializeField]
    private float extraTime;

    [SerializeField]
    private float interactMultLeader;
    [SerializeField]
    private float interactMultLast;




    private void Awake()
    {
       // timerText.gameObject.SetActive(false);
      // gameStatsText.gameObject.SetActive(false);
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

        int pointCheck = 0;
        foreach (PlayerController player in players)
        {
            pointCheck += player.points;
        }

        if (pointCheck > 0)
        {

            for (int i = 0; i < playersToRank.Count; i++)
            {
                if (i == 0)
                {
                    playersToRank[i].interactMultiplier = interactMultLeader;

                }
                else if (i == playersToRank.Count - 1)
                {
                    playersToRank[i].interactMultiplier = interactMultLast;
                }
                else
                {
                    playersToRank[i].interactMultiplier = 1;
                }
            }
        }


    }

    public void EndGame()
    {
        if (playersToRank[0].points == playersToRank[1].points && playersToRank[0].killCount == playersToRank[1].killCount)
        {
            timer += extraTime;
        }
        //Display Victory Screen and show the winner, second, etc.
    }



}