using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(AudioSource))]
public class InteractableObj : BaseObject
{

    public float waitTime;
    public Vector2Int interactionPos;
    public TaskType taskType = TaskType.none;

    public AudioClip taskClip;
    public AudioSource taskSpeaker;

    [HideInInspector]
    public GameObject visualIndicator;

    public UnityEvent TaskStarted;

    public UnityEvent TaskInterrupted;

    public UnityEvent TaskCompleted;
    protected virtual void Awake()
    {
        visualIndicator = GetComponentInChildren<UVScroller_C>()?.gameObject;
        taskSpeaker = GetComponent<AudioSource>();
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