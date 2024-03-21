using System.Collections.Generic;
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
                taskToDo.Add(taskObj.taskType);
            Debug.Log("Task: " + taskObj.taskType);
        }

        //make sure they don't get the same task
    }

    public void CompleteTask(InteractableObj task)
    {
        //Invoke 
        OnTaskComplete?.Invoke();
        Debug.Log("Task Completed: " + task.taskType);
        taskToDo.Remove(task.taskType);
        completedTask = task.taskType;
        SearchTask();
    }

}
