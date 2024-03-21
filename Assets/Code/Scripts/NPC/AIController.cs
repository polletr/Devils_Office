using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
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
        Invoke(nameof(StartThinking), 0.5f);   // use catch event instead of invoke
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
        Debug.Log("Roam");

        float timer = 0f;

        while (currentAction == AITasks.Roam)
        {

            timer += Time.deltaTime;
            int randomNumber = Random.Range(0, 6);
            if (currentState is IdleState)
            {
                if (timer > Random.Range(0.2f, 0.6f))
                {
                    SetBrain(AITasks.Think);
                    break;
                }

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
                    if (GridController.Instance.CanMove(gridLocation + fwdDirection))
                        ChangeState(new MoveState());
                    else
                        ChangeState(new RotateLeftState());
                }


            }

            yield return new WaitForSeconds(1f);
        }
    }
    private IEnumerator OnDoTasks()
    {
        InteractableObj destObj = GridController.Instance.interactableObjs[Random.Range(0, GridController.Instance.interactableObjs.Count)];
        Vector2Int destination = destObj.interactionPos;

        Debug.Log("Do Tasks");

        float timer = 0f;
        while (currentAction == AITasks.DoTask && (GridController.Instance.gridLocations[destination.x, destination.y] == 0 || destination == gridLocation))
        {
/*            if (GridController.Instance.gridLocations[destination.x, destination.y] == 0 || destination == gridLocation)
            {
*/                
                timer += Time.deltaTime;
                if (destination != gridLocation && currentState is IdleState && timer > Random.Range(0.7f, 2f))
                {
                    Debug.Log("MoveToLocation");
                    path = pathFinder.GetPath(gridLocation, destination);

                    Vector2Int nextDestination = path.Pop();
                    //  fwdDirection = nextDestination - gridLocation; //get direction to move
                    MoveToLocation(nextDestination);

                    timer = 0f;
                }
                else if (destination == gridLocation && currentState is IdleState && !doneInteracting)
                {
                    Debug.Log("COmpleteTask");
                    CompleteTask(destObj.posInGrid);
                    //doneInteracting = true;

                }
                else if (currentState is IdleState && doneInteracting)
                {
                    Debug.Log("FinishTask");

                    doneInteracting = false;
                    ChangeState(new RotateLeftState());
                    SetBrain(AITasks.Roam);
                }

/*            }
*//*            else if(GridController.Instance.gridLocations[destination.x, destination.y] != 0 && destination != gridLocation)
            {
                break;
            }
*/

            yield return null;
        }

        SetBrain(AITasks.Think);


    }

    #endregion


    private void MoveToLocation(Vector2Int nextDestination)
    {
        Vector2Int moveDirection = nextDestination - gridLocation;
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
        Debug.Log("DoingTask");
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
