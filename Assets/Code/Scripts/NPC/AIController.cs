using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class AIController : CharacterClass
{
    Vector2 currentPos;
    Vector2 targetPos;
    bool doneInteracting;

    private PathFinder pathFinder;

    bool _iskilled;
    int num = 0;


    private Stack<Vector2Int> path = new Stack<Vector2Int>();


    public override void Awake()
    {
        base.Awake();
        Invoke(nameof(StartThinking), 2f);   // use catch event instead of invoke
        ChangeState(new IdleState());
        pathFinder = GetComponent<PathFinder>();
        pathFinder.SetGridFromController();

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
        Debug.Log("Thinking");
        SetBrain((AITasks)Random.Range(1, Enum.GetValues(typeof(AITasks)).Length));
/*        num = (num + 1) % Enum.GetValues(typeof(AITasks)).Length;
        if (num == 0)
        {
            num = 1;
        }
        SetBrain((AITasks)num);
*/
        //SetBrain(AITasks.Roam);
        //SetBrain(AITasks.DoTask);
    }
    private IEnumerator OnRoaming()
    {
        float timer = 0f;

        while (currentAction == AITasks.Roam)
        {
            timer += Time.deltaTime;
            int randomNumber = Random.Range(0, 7);
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

            if (currentState is IdleState && timer > Random.Range(0.1f,0.4f))
            {
                SetBrain(AITasks.Think);
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    private IEnumerator OnDoTasks()
    {
        InteractableObj destObj = GridController.Instance.interactableObjs[Random.Range(0, GridController.Instance.interactableObjs.Count)];
        Vector2Int destination = destObj.interactionPos;


        float timer = 0f;
        while (currentAction == AITasks.DoTask)
        {
            if (GridController.Instance.gridLocations[destination.x, destination.y] != 0 && destination != gridLocation && currentState is IdleState)
            {
                SetBrain(AITasks.Roam);
            }
            else
            {
                path = pathFinder.GetPath(gridLocation, destination);
                timer += Time.deltaTime;
                if (path.Count > 0 && currentState is IdleState && timer > Random.Range(0.7f, 2f))
                {
                    Vector2Int nextDestination = path.Pop();
                    //  fwdDirection = nextDestination - gridLocation; //get direction to move
                    MoveToLocation(nextDestination);
                    timer = 0f;
                }
                else if (path.Count == 0 && currentState is IdleState && !doneInteracting)
                {
                    CompleteTask(destObj.posInGrid);
                }
                else if (currentState is IdleState && doneInteracting)
                {
                    doneInteracting = false;
                    ChangeState(new RotateLeftState());
                    SetBrain(AITasks.Roam);
                }

            }

            yield return null;
        }

    }

    #endregion


    private void MoveToLocation(Vector2Int nextDestination)
    {
        Vector2Int moveDirection = nextDestination - gridLocation;
        Debug.Log("MOVE DIRECTION" + moveDirection);
        if (moveDirection == fwdDirection)
        {
            ChangeState(new MoveState());
            pathFinder.SetGridFromController();
        }
        else
        {
            int crossProduct = (int)(fwdDirection.x * moveDirection.y - fwdDirection.y * moveDirection.x);
            if (crossProduct > 0)
            {
                ChangeState(new RotateLeftState());
            }
            else if (crossProduct < 0)
            {
                ChangeState(new RotateRightState());
            }
            else
            {
                ChangeState(new RotateRightState());
            }
        }
    }

    private void CompleteTask(Vector2Int ObjPos)
    {
        Vector2Int moveDirection = ObjPos - gridLocation;
        if (moveDirection == fwdDirection)
        {
            ChangeState(new InteractState());
            doneInteracting = true;
        }
        else
        {
            int crossProduct = (int)(fwdDirection.x * moveDirection.y - fwdDirection.y * moveDirection.x);

            if (crossProduct > 0)
            {
                ChangeState(new RotateLeftState());
            }
            else if (crossProduct < 0)
            {
                ChangeState(new RotateRightState());
            }
            else
            {
                ChangeState(new RotateRightState());
            }

        }
    }

    private void StartThinking()
    {
        SetBrain(AITasks.Think);
    }

    public enum AITasks
    {
        Think,
        Roam ,
        DoTask 
    }





}
