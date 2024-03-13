using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveState : BaseState
{
    private Vector2Int moveDirection;
    Vector3 nextLocation;

    public override void EnterState()
    {
        //Play Animation
        moveDirection = new Vector2Int(0,1);

        if (GridController.Instance.CanMove(player.gridLocation + moveDirection))
        {
            player.gridLocation += moveDirection;
            nextLocation = GridController.Instance.GetGridLocation(player.gridLocation);
        }
        else
        {
            player.ChangeState(new IdleState());
        }


    }

    public override void ExitState()
    {
        base.ExitState();
    }


    public override void StateFixedUpdate()
    {
        Debug.Log("Move");
        Debug.Log(GridController.Instance.CanMove(player.gridLocation));

        if (Vector3.Distance(player.transform.position, nextLocation) > 0.01f)
        {
            float step = player.moveSpeed * Time.fixedDeltaTime;

            player.transform.position = Vector3.MoveTowards(player.transform.position, nextLocation, step);
        }
        else
        {
            player.transform.position = nextLocation;
            player.ChangeState(new IdleState());
        }
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }


}
