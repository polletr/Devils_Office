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
        player.ChangeState(new MoveState());
    }


}
