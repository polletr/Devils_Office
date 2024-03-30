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


    private TaskManager taskManager;
    private PlayerController player;
    [HideInInspector]
    public bool showUI;
    [HideInInspector]
    public bool showLoader;

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

    public void GameStats(string stats)
    {
        gameStats.gameObject.SetActive(true);
        gameStats.text = stats;
        if(stats == "Winner")
            gameStats.color = Color.green;
        else
            gameStats.color = Color.red;
    }

    /*        if (Enum.TryParse(player.controlScheme, out PlayerID playerID))
       {
         switch(playerID)
           {
           case PlayerID.P0:
                  // GameManager.Instance.
             break;
           case PlayerID.P1:
             break;
           case PlayerID.P2:
             break;
           case PlayerID.P3:
             break;
         }
       }
*/
}


