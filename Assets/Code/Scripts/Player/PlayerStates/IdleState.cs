using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void EnterState()
    {
        //Play animation
        Debug.Log("Enter Idle");
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
        player.ChangeState(new MoveState());
    }

    public override void HandleRotation(float rotateAngle)
    {

        if (rotateAngle < 0)
        {
            player.ChangeState(new RotateLeftState());
        }
        else
        {
            player.ChangeState(new RotateRightState());
        }


    }



}
