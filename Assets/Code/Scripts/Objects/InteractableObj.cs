using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : BaseObject
{

    public float waitTime;
    public Vector2Int interactionPos;
    public TaskType taskType = TaskType.none;


}

public enum TaskType
{
  Coffee,
  pitchFork,
  none
}