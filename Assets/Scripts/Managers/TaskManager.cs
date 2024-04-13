using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    [Header("Task Values")]
    [SerializeField]
    int maxTasks = 2;
    public List<TaskType> taskToDo = new();
    public TaskType completedTask;

    [Header("UI Task")]
    [SerializeField]
    GameObject taskUI;//UI for task

    [Header("Events")]
    public UnityEvent OnTaskComplete;

    [SerializeField]
    private Camera playerCamera;


    private void Start()
    {
        SearchTask();
    }

    public void SearchTask()
    {
        if (GridController.Instance.interactableObjs.Count < maxTasks)
        {
            Debug.LogWarning("Not enough tasks to do");
        }

        while (taskToDo.Count < maxTasks && GridController.Instance.interactableObjs.Count > maxTasks)
        {
            InteractableObj taskObj = GridController.Instance.interactableObjs[Random.Range(0, GridController.Instance.interactableObjs.Count)];//get random task object

            if (!taskToDo.Contains(taskObj.taskType) && taskObj.taskType != completedTask) //make sure they don't get the same task in the list or they're 
            {
                taskToDo.Add(taskObj.taskType);

                playerCamera.cullingMask ^= 1 << taskObj.visualIndicator.layer;

            }
            if(GetComponent<PlayerController>())
            AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.NewTask);
            Debug.Log("Task: " + taskObj.taskType);
        }

        //make sure they don't get the same task
    }

    public void CompleteTask(InteractableObj task)
    {
        //Invoke
        if (!taskToDo.Contains(TaskType.ExtinguishBody) || task.taskType == TaskType.ExtinguishBody)
        {
            if (task != null)
            playerCamera.cullingMask ^= 1 << task.visualIndicator.layer;

            taskToDo.Remove(task.taskType);
            completedTask = task.taskType;
            OnTaskComplete?.Invoke();
            AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.TaskDone);

            SearchTask();
        }
        else
        {
            Debug.Log("Extinguish body first");
        }
    }

    public void AddExtinguishTask(InteractableObj AI)
    {
        foreach(InteractableObj task in GridController.Instance.interactableObjs)
        {
            if (taskToDo.Contains(task.taskType))
            {
                playerCamera.cullingMask ^= 1 << task.visualIndicator.layer;
                break;
            }
        }

        taskToDo.Clear();

        taskToDo.Add(TaskType.ExtinguishBody);
        AI.visualIndicator.SetActive(true);
        playerCamera.cullingMask ^= 1 << AI.visualIndicator.layer;


    }

}
