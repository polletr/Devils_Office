using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

[RequireComponent(typeof(InputManager))]
public class PlayerController : CharacterClass
{

    public string controlScheme;

    public override void Awake()
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

    #region character Actions
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
        else if (false)//check if can attack
        {
            ChangeState(new AttackState());
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
