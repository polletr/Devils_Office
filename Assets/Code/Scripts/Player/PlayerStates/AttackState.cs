using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : BaseState
{
    public override void EnterState()
    {
        //Play Animation

        if (GridController.Instance.CanAttack(character.gridLocation + character.fwdDirection))
        {
            
        }
        else
        {
            character.ChangeState(new IdleState());
        }

    }

}
