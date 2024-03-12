using System;
using System.Collections;
using UnityEngine;

public class AIController : MonoBehaviour
{

    Vector2 currentDirection;

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
    private State currentState;

    private void Start()
    {
        SetState(State.Idle);
    }

    private void SetState(State newState)
    {
        currentState = newState;
        StopAllCoroutines();

        switch (currentState)
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
        //PickAction();
    }
    private IEnumerator OnMoving()
    {
        while (currentState == State.Moving)
        {
            yield return null;
        }
    }
    private IEnumerator OnTurning()
    {
        while (currentState == State.Turning)
        {
            yield return null;
        }
    }
    private IEnumerator OnCremated()
    {
        while (currentState == State.Turning)
        {
            yield return null;
        }
    }
    private IEnumerator OnDied()
    {
        while (currentState == State.Turning)
        {
            yield return null;
        }
    }
    private IEnumerator OnStare()
    {
        while (currentState == State.Stare)
        {
            yield return null;
        }
    }
    private IEnumerator OnDoTasks()
    {
        while (currentState == State.DoTasks)
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
