using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObj : BaseObject
{

    public float waitTime;
    public Vector2Int interactionPos;
    public TaskType taskType = TaskType.none;

    [HideInInspector]
    public GameObject visualIndicator;
    
    public UnityEvent TaskStarted;

    public UnityEvent TaskInterrupted;

    public UnityEvent TaskCompleted;
    void Awake()
    {
        visualIndicator = GetComponentInChildren<UVScroller_C>()?.gameObject;
    }


}


public enum TaskType
{
  Coffee,
  Pitchfork,
  ExtinguishBody,
  Stamp,
  Printer,
  PC,
  Microwave,
  Telephone,
  none
}