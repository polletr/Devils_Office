using System;
using System.Collections;
using UnityEngine;

public class AIController : BaseObject
{
    [HideInInspector]
    public Vector2Int fwdDirection;

    public BaseState currentState;

    [HideInInspector]
    public Vector2Int gridLocation;
    public Vector3 Position => transform.position;
    [HideInInspector]
    public Animator anim;

    public float moveSpeed = 1f;
    public float rotateSpeed = 1f;

    private void Awake()
    {
        fwdDirection = new Vector2Int(0, 1);
                SetState(State.Idle);

    }
    private void Update()
    {
        currentState?.StateUpdate();
    }
    private void FixedUpdate()
    {
        currentState?.StateFixedUpdate();
    }

    public void ChangeState(BaseState newState)
    {
        StartCoroutine(WaitFixedFrame(newState));
    }

    private IEnumerator WaitFixedFrame(BaseState newState)
    {
        yield return new WaitForFixedUpdate();
        currentState?.ExitState();
        currentState = newState;
        currentState.AI = this;
        currentState.EnterState();
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

    Vector2 currentPos;
    Vector2 targetPos;

    bool _iskilled;

    public enum State
    {
        Idle,
        Moving,
        Turning,
        DoTasks,
        Stare,
        Died,
        Cremated
    }
    private State currentAction;

    private void SetState(State newState)
    {
        currentAction = newState;
        StopAllCoroutines();

        switch (currentAction)
        {
            case State.Idle:
                OnIdle();
                break;
            case State.Moving:
                StartCoroutine(OnMoving());
                break;
            case State.Turning:
                StartCoroutine(OnTurning());
                break;
            case State.DoTasks:
                StartCoroutine(OnDoTasks());
                break;
            case State.Stare:
                StartCoroutine(OnStare());
                break;
            case State.Died:
                StartCoroutine(OnDied());
                break;
            case State.Cremated:
                StartCoroutine(OnCremated());
                break;
            default:
                break;
        }


    }

    #region AI States

    public void OnIdle()
    {
        ChangeState(new IdleState());
        //Process Next Action to do 
    }
    private IEnumerator OnMoving()
    {
        while(currentAction == State.Moving)
        {
            ChangeState(new MoveState());
            yield return null;
        }
    }
    private IEnumerator OnTurning()
    {
        while (currentAction == State.Turning)
        {
            yield return null;
        }
    }
    private IEnumerator OnCremated()
    {
        while (currentAction == State.Turning)
        {
            yield return null;
        }
    }
    private IEnumerator OnDied()
    {
        while (currentAction == State.Turning)
        {
            yield return null;
        }
    }
    private IEnumerator OnStare()
    {
        while (currentAction == State.Stare)
        {
            yield return null;
        }
    }
    private IEnumerator OnDoTasks()
    {
        while (currentAction == State.DoTasks)
        {
            yield return null;
        }
    }

    #endregion

    #region AI Checks
    enum MoveTo
    {
        MoveToTask,
        MoveToPlayer,
        MoveToRandomPos,
    }

    private void PickAction()
    {
        SetState((State)UnityEngine.Random.Range(0, Enum.GetValues(typeof(State)).Length));
    }

    private void MoveAITo(MoveTo moveTo)
    {
        switch (moveTo)
        {
            case MoveTo.MoveToTask:
                targetPos = RandomTask();
                break;
            case MoveTo.MoveToPlayer:
                targetPos = ClosePlayer();
                break;
            case MoveTo.MoveToRandomPos:
                targetPos = new Vector2(UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2));
                break;
            default:
                break;
        }
    }

    private Vector2 ClosePlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 10f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                return targetPos = collider.transform.position;
            }
        }
        return this.transform.position;
    }
    private Vector2 RandomTask()
    {
        /*        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 10f);
                foreach (Collider collider in colliders)
                {
                    if (collider.CompareTag("Player"))
                    {
                        return targetPos = collider.transform.position;
                    }
                }
             */
        return this.transform.position;
    }

    public void KilledByPlayer()
    {
        SetState(State.Died);
    }

    #endregion

}
