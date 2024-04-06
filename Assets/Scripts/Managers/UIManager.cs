using System.Collections;
using TMPro;
using Unity.Loading;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject playerUI;
    [SerializeField]
    private TextMeshProUGUI[] taskText;
    [SerializeField]
    private TextMeshProUGUI pointsText;
    [SerializeField]
    private Image loaderImageUI;
    [SerializeField]
    private TextMeshProUGUI gameStats;
    [SerializeField]
    private CanvasGroup playerEye;
    [SerializeField]
    private float blinkDuration = 0.5f;


    private TaskManager taskManager;
    private PlayerController player;
    [HideInInspector]
    public bool showUI;
    [HideInInspector]
    public bool showLoader;

    [SerializeField]
    private GameObject dieText;

    // Start is called before the first frame update
    void Awake()
    {
        taskManager = GetComponentInParent<TaskManager>();
        player = GetComponentInParent<PlayerController>();
        showUI = false;
        showLoader = false;
        gameStats.gameObject.SetActive(false);
        DisableUI(showUI);
        loaderImageUI.fillAmount = 0;

    }

    private void UpdateUI()
    {
        //task
        for (int i = 0; i < taskManager.taskToDo.Count; i++)
        {
            taskText[i].text = taskManager.taskToDo[i].ToString();
        }

        if (taskManager.taskToDo.Count < taskText.Length)
        {
            for (int i = taskManager.taskToDo.Count; i < taskText.Length; i++)
            {
                taskText[i].text = "";
            }
        }
        //loader
        loaderImageUI.gameObject.SetActive(showLoader);
        //points
        pointsText.text = "Points: " + player.points.ToString();

        if(player.points >= 100)
        { 
         AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.playerOneIsBeing);
        }
    }
    void Update()
    {
        UpdateUI();

    }

    public void DisableUI(bool b)
    {
        for (int i = 0; i < taskText.Length; i++)
        {
            taskText[i].gameObject.SetActive(b);
        }
    }

    public void LoadingBar(float indicator, float maxIndicator)
    {
        loaderImageUI.fillAmount = indicator / maxIndicator;
    }

    public void GameStats(PlayerController winner)
    {
        gameStats.gameObject.SetActive(true);
        if (winner == player)
        {
            gameStats.color = Color.green;
            gameStats.text = "You Win!";
        }
        else
        {
            gameStats.color = Color.red;
            gameStats.text = "You Lose!";

        }
    }

    public IEnumerator Blink(bool closeEye)
    {
        Debug.Log("Blink");
        float targetAlpha = closeEye ? 1f : 0f; 
        float elapsedTime = 0f; 

        while (elapsedTime < blinkDuration)
        {
            playerEye.alpha = Mathf.Lerp(playerEye.alpha, targetAlpha, elapsedTime / blinkDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        playerEye.alpha = targetAlpha;

        if (player.currentState is DeathState)
        {
            dieText.gameObject.SetActive(closeEye);
        }
    }


}


