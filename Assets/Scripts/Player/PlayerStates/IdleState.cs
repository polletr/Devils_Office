using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void EnterState()
    {
        //Play animation
        base.EnterState();
    }

    public override void ExitState() 
    { 
        base.ExitState();
    }


    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
        
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void HandleMovement()
    {
        character.ChangeState(new MoveState());
    }

    public override void HandleRotation(float rotateAngle)
    {

        if (rotateAngle < 0)
        {
            character.ChangeState(new RotateLeftState());
        }
        else
        {
            character.ChangeState(new RotateRightState());
        }


    }

    public override void HandleInteract()
    {
        if (GridController.Instance.CanInteract(character.gridLocation + character.fwdDirection, character.GetComponent<PlayerController>()?._taskManager))   // can incteract , in the task list             
        {
            Debug.Log("Interact");
            character.ChangeState(new InteractState());
        }
        else if (GridController.Instance.CanAttack(character.gridLocation + character.fwdDirection, character.fwdDirection))//check if can attack
        {
            Debug.Log("Attack!");
            character.ChangeState(new AttackState());
        }
        else
        {
            //Close Eyes
        }

    }

    public override void HandleDeath()
    {
        character.ChangeState(new DeathState());
    }



}
