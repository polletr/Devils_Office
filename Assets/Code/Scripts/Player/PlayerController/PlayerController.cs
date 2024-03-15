using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

[RequireComponent(typeof(InputManager))]
public class PlayerController : CharacterClass
{
    public BaseState currentState;
    [HideInInspector]
    public Vector2Int gridLocation;
    public Vector3 Position => transform.position;

    [HideInInspector]
    public Animator anim;

    public float moveSpeed = 1f;
    public float rotateSpeed = 1f;

    protected override void Awake()
    {
        base.Awake();
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
    }

    public void HandleRotate(float rotateAngle)
    {
        currentState?.HandleRotation(rotateAngle);
    }
    public void HandleAttack()
    {
        ChangeState(new AttackState());
    }
    public void HandleInteract()
    {
        if (GridController.Instance.CanInteract(gridLocation + fwdDirection))
        {
            ChangeState(new InteractState());
        }
    }

    public void HandleStopInteract()
    {
        currentState?.StopInteract();
    }

    public void HandleViewTask()
    {
        //Define if we want the player to move or not
    }


    #endregion

}
