using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private float timer = 80f;
   
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject winScreen;

    [SerializeField]
    public Transform[] spawnPoints;

    public int taskPoints;

    public int killPoints;

    public List<PlayerController> playersToRank = new();

    private float extraTime;

    [SerializeField]
    private float interactMultLeader;
    [SerializeField]
    private float interactMultLast;

    private int extraTimerCount;
    [SerializeField]
    private float extraTimeCountLimit;


    private void Awake()
    {
        timerText.gameObject.SetActive(false);
        winScreen.SetActive(false);
        extraTimerCount = 0;
        extraTime = timer / 2f;
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
        if (timer > 0.1f)
        {
            timer -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer % 60F);
            //int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
            if (timerText != null && timer <= extraTime)
            {
                timerText.gameObject.SetActive(true);
                timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); // + ":" + milliseconds.ToString("00");   
            }
        }
        else
        {
            EndGame();
        }
    }

    public void RankPlayers(List<PlayerController> players)
    {
        playersToRank = players.OrderByDescending(p => p.points).ThenByDescending(p => p.killCount).ToList();

        bool pointCheck = false;

        for (int i = 0; i < playersToRank.Count - 1; i++)
        {
            if (playersToRank[i].points == playersToRank[i + 1].points)
            {
                pointCheck = false;
            }
            else
            {
                pointCheck = true;
                break;
            }
        }

        if (pointCheck)
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

            for (int i = 0; i < playersToRank.Count - 1; i++)
            {
                if (playersToRank[i].points == playersToRank[i + 1].points && playersToRank[i].interactMultiplier != 1)
                {
                    playersToRank[i + 1].interactMultiplier = playersToRank[i].interactMultiplier;
                }
                else if (playersToRank[i].points == playersToRank[i + 1].points && playersToRank[i].interactMultiplier == 1)
                {
                    if (playersToRank[i].points == playersToRank[playersToRank.Count - 1].points)
                    {
                        playersToRank[i].interactMultiplier = playersToRank[playersToRank.Count - 1].interactMultiplier;
                    }
                }

            }


        }
        else
        {
            for (int i = 0; i < playersToRank.Count; i++)
            {
                playersToRank[i].interactMultiplier = 1;
            }

        }



    }

    public void EndGame()
    {
        if (playersToRank[0].points == playersToRank[1].points && playersToRank[0].killCount == playersToRank[1].killCount)
        {
            extraTimerCount++;
            if (extraTimerCount > extraTimeCountLimit)
            {
                for (int i = 0; i < playersToRank.Count; i++)
                {
                    playersToRank[i]._UIManager.GameStats(null);
                }
                Time.timeScale = 0;
                winScreen.SetActive(true);
            }
            else
            {
                timer += extraTime;
            }

        }
        else
        {
            for (int i = 0; i < playersToRank.Count; i++)
            {
                playersToRank[i]._UIManager.GameStats(playersToRank[0]);
            }
            Time.timeScale = 0;
            winScreen.SetActive(true);

            //Display Victory Screen and show the winner, second, etc.
        }
    }



}