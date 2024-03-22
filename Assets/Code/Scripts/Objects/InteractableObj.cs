using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObj : BaseObject
{

    public float waitTime;
    public Vector2Int interactionPos;
    public TaskType taskType = TaskType.none;
    
    public UnityEvent TaskStarted;

    public UnityEvent TaskInterrupted;

    public UnityEvent TaskCompleted;


}

public enum TaskType
{
  Coffee,
  pitchFork,
  ExtinguishBody,
  none
}