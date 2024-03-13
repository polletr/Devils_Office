using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

[RequireComponent(typeof(InputManager))]
public class PlayerController : MonoBehaviour
{
    public BaseState currentState;

    public Vector2Int gridLocation;

    public Vector3 Position => transform.position;

    [HideInInspector]
    public Animator anim;

    public float moveSpeed = 1f;

    private void Awake()
    {
        ChangeState(new IdleState());
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
        currentState.player = this;
        currentState.EnterState();

    }

    #region Player Actions
    public void HandleMove()
    {
        currentState?.HandleMovement();
        Debug.Log("Press");

    }
    public void HandleKill()
    {
        Debug.Log("Killed");

    }
    public void HandleInteract()
    {

    }
    public void HandleViewTask()
    {

    }


    #endregion

}
