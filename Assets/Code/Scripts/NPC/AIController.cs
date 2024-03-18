using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIController : CharacterClass
{
    Vector2 currentPos;
    Vector2 targetPos;

    bool _iskilled;


    protected override void Awake()
    {
        base.Awake();
        SetBrain(AITasks.Think);
        // GridController.Instance.objLocations[(int)transform.position.x, (int)transform.position.z] = ;

    }
    private void Update()
    {
        currentState?.StateUpdate();
    }
    private void FixedUpdate()
    {
        currentState?.StateFixedUpdate();
    }

    #region AI Actions
    public void HandleMove()
    {
        currentState?.HandleMovement();
    }
    public void HandleRotate(float rotateAngle)
    {
        currentState?.HandleRotation(rotateAngle);
    }
    public void HandleInteract()
    {

    }


    #endregion

    private AITasks currentAction;

    private void SetBrain(AITasks newState)
    {
        currentAction = newState;
        StopAllCoroutines();

        switch (currentAction)
        {
            case AITasks.Think:
                OnThinking();
                break;
            case AITasks.Roam:
                StartCoroutine(OnRoaming());
                break;
            case AITasks.DoTask:
                StartCoroutine(OnDoTasks());
                break;
            default:
                break;
        }
    }

    #region AI States

    public void OnThinking()
    {
        SetBrain((AITasks)Random.Range(1, Enum.GetValues(typeof(AITasks)).Length));
    }
    private IEnumerator OnRoaming()
    {
        while (currentAction == AITasks.Roam)
        {
            ChangeState(new MoveState());
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0)
            {
                ChangeState(new RotateLeftState());
            }
            else
            {
                ChangeState(new RotateRightState());
            }
            yield return new WaitForSeconds(Random.Range(30,60));
        }
    }
    private IEnumerator OnDoTasks()
    {
        while (currentAction == AITasks.DoTask)
        {
            yield return null;
        }
    }



    #endregion

    public enum AITasks
    {
        Think,
        Roam,
        DoTask
    }



}
