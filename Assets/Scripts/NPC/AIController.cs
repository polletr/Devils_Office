using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIController : CharacterClass
{
    Vector2 currentPos;
    Vector2 targetPos;
    bool doneInteracting;

    private PathFinder pathFinder;

    bool _iskilled;

    private Stack<Vector2Int> path = new Stack<Vector2Int>();

    [SerializeField]
    private float roamTimerMin;
    [SerializeField]
    private float roamTimerMax;

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

        while (currentAction == AITasks.Roam && currentState is not DeathState)
        {

            timer += Time.deltaTime;
            int randomNumber = Random.Range(0, 4);
            if (currentState is IdleState)
            {
                if (timer > Random.Range(roamTimerMin, roamTimerMax))
                {
                    SetBrain(AITasks.Think);
                }

                if (randomNumber == 0)
                {
                    RandomRotate();
                }
                else
                {
                    if (GridController.Instance.CanMove(gridLocation + fwdDirection))
                        ChangeState(new MoveState());
                    else
                        RandomRotate();
                }


            }

            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }
    private IEnumerator OnDoTasks()
    {
        InteractableObj destObj = GridController.Instance.interactableObjs[Random.Range(0, GridController.Instance.interactableObjs.Count)];
        Vector2Int destination = destObj.interactionPos;

        float timer = 0f;
        while (currentAction == AITasks.DoTask && (GridController.Instance.gridLocations[destination.x, destination.y] == 0 || destination == gridLocation) && currentState is not DeathState)
        {

            timer += Time.deltaTime;
            if (gridLocation != destination && currentState is IdleState && timer > Random.Range(1.5f, 2.5f))
            {
                path = pathFinder.GetPath(gridLocation, destination);

                if (path.Count > 0)
                {
                    Vector2Int nextDestination = path.Pop();
                    //  fwdDirection = nextDestination - gridLocation; //get direction to move
                    MoveToLocation(nextDestination);
                }

                timer = 0f;
            }
            else if (gridLocation == destination && currentState is IdleState && !doneInteracting)
            {
                CompleteTask(destObj.posInGrid);
                //doneInteracting = true;

            }
            else if (currentState is IdleState && doneInteracting)
            {

                doneInteracting = false;
                RandomRotate();
                SetBrain(AITasks.Roam);
            }

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
                RandomRotate();
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
                RandomRotate();
            }

        }
    }

    private void StartThinking()
    {
        anim = GetComponentInChildren<Animator>();

        SetBrain(AITasks.Think);
    }

    private void RandomRotate()
    {
        currentState?.HandleRotation((Random.Range(0, 2) * 2 - 1) * 90f);
    }

    public void DestroySelf()
    {
        GridController.Instance.AIList.Remove(this);
        Destroy(this.gameObject);
    }


    public enum AITasks
    {
        Think,
        Roam,
        DoTask
    }





}
