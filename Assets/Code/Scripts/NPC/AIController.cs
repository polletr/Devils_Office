using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIController : CharacterClass
{
    Vector2 currentPos;
    Vector2 targetPos;

    bool _iskilled;

    private Stack<Vector2Int> path = new Stack<Vector2Int>();


    public override void Awake()
    {
        base.Awake();
        Invoke(nameof(startThinking),1f);
        ChangeState(new IdleState());
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
        //SetBrain((AITasks)Random.Range(1, Enum.GetValues(typeof(AITasks)).Length));
        SetBrain(AITasks.Roam);
        //SetBrain(AITasks.DoTask);
    }
    private IEnumerator OnRoaming()
    {
        float timer = 0f;

        while (currentAction == AITasks.Roam)
        {
            Debug.Log(currentState);
            timer += Time.deltaTime;
            if (timer < Random.Range(5f, 20f))
            {
                int randomNumber = Random.Range(0, 3);
                if (currentState is IdleState)
                {
                    if (randomNumber == 0)
                    {
                        ChangeState(new RotateLeftState());
                    }
                    else if (randomNumber == 1)
                    {
                        ChangeState(new RotateRightState());
                    }
                    else
                    {
                        ChangeState(new MoveState());
                    }
                }
            }
            else if (currentState is IdleState state)
            {
                SetBrain(AITasks.Think);
            }
            yield return new WaitForSeconds(Random.Range(0.1f, 8f));
        }
    }
    private IEnumerator OnDoTasks()
    {
        Debug.Log("THIS IS IT" + GridController.Instance.interactableObjs[0].posInGrid);
        Vector2Int destination = GridController.Instance.interactableObjs[Random.Range(0, GridController.Instance.interactableObjs.Count)].posInGrid;
        while (currentAction == AITasks.DoTask)
        {

            path = PathFinder.Instance.GetPath(gridLocation, destination);

            if (path.Count != 0)
            {
                Vector2Int nextDestination = path.Pop();
                 MoveToLocation(nextDestination);
                fwdDirection = nextDestination - gridLocation;
            }
           /* else
            {
               // CompleteTask();
            }*/


            yield return null;
        }
    }

    #endregion


    private void MoveToLocation(Vector2 target)
    {
        //check direction of next pop 

        if (target == posInGrid + fwdDirection) // (move)
        {

        }
        //else turn to direction and try again
    }
    private void CompleteTask()
    {
        ChangeState(new InteractState());
    }

    private void startThinking()
    {
        SetBrain(AITasks.Think);
    }

    public enum AITasks
    {
        Think,
        Roam,
        DoTask
    }





}
