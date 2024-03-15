using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveState : BaseState
{
    Vector3 nextLocation;
    Vector2Int oldLocation;
    bool canMove;

    public override void EnterState()
    {

        if (GridController.Instance.CanMove(player.gridLocation + player.fwdDirection))
        {
            canMove = true;
            //Play Animation

            oldLocation = player.gridLocation;
            player.gridLocation += player.fwdDirection;

            nextLocation = GridController.Instance.GetGridLocation(player.gridLocation);
        }
        else
        {
            canMove = false;
            player.ChangeState(new IdleState());
        }

    }

    public override void ExitState()
    {
        base.ExitState();
    }


    public override void StateFixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, nextLocation) > 0.01f && canMove)
        {
            float step = player.moveSpeed * Time.fixedDeltaTime;

            player.transform.position = Vector3.MoveTowards(player.transform.position, nextLocation, step);
        }
        else if(canMove)
        {
            GridController.Instance.objLocations[oldLocation.x, oldLocation.y] = null;
            GridController.Instance.objLocations[(int)nextLocation.x, (int)nextLocation.y] = player;
            player.transform.position = nextLocation;
            player.ChangeState(new IdleState());
        }
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }


}
