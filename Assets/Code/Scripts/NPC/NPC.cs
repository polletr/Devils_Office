using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Vector2 currentDirection;
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

    /* private void SetState(State newState)
     {
         currentState = newState;
         StopAllCoroutines();

         switch (currentState)
         {
             case State.Idle:
                 StartCoroutine(OnIdle());
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


     }*/

    #region AI States

    IEnumerator OnIdle()
    {
        while (currentState == State.Idle)
        {
            yield return null;
        }
    }

    IEnumerator OnMoving()
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



        #endregion

        #region AI Checks




        #endregion





    }
}