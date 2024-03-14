using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : BaseState
{
    public override void EnterState()
    {
        //Play Animation

        if (GridController.Instance.CanAttack(player.gridLocation + player.fwdDirection))
        {
            
        }
        else
        {
            player.ChangeState(new IdleState());
        }

    }

}
