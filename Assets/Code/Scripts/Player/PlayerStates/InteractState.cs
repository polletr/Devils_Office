using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractState : BaseState
{
    public override void EnterState()
    {
        //Play Animation

        if (GridController.Instance.CanInteract(player.gridLocation + player.fwdDirection))
        {

        }
        else
        {
            player.ChangeState(new IdleState());
        }

    }
}
