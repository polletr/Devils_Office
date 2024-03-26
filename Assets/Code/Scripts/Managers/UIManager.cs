using System;
using TMPro;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    public GameObject playerUI;
    [SerializeField]
    private TextMeshProUGUI[] taskText;
    [SerializeField]
    private TextMeshProUGUI pointsText;

    private TaskManager taskManager;
    private PlayerController player;

   private PlayerID playerID;
    // Start is called before the first frame update
    void Awake()
    {
        taskManager = GetComponentInParent<TaskManager>();
        player = GetComponentInParent<PlayerController>();
                                
       
        if(Enum.TryParse(player.controlScheme, out PlayerID playerID))
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


        //points
        pointsText.text = "Points: " + player.points.ToString();
    }
    void Update()
    {
        UpdateUI();
    }

    private enum PlayerID
    {
        P0,
        P1,
        P2,
        P3
    }



}
