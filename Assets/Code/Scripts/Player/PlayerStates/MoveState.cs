using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveState : BaseState
{
    private bool isMoving;
    private Vector2Int moveDirection;

    public float blendValue = .01f;

    public override void EnterState()
    {
        //Play Animation
        moveDirection = new Vector2Int(0,1);
        isMoving = true;
    }

    public override void ExitState()
    {
        base.ExitState();
    }


    public override void StateFixedUpdate()
    {
        if (GridController.Instance.CanMove(player.gridLocation + moveDirection) && isMoving)
        {
            Vector3 currentLocation = player.transform.position;
            player.gridLocation += moveDirection;
            Vector3 nextLocation = GridController.Instance.GetGridLocation(player.gridLocation);

            if (player.transform.position != nextLocation)
            {
                player.transform.position = Vector2.Lerp(currentLocation, nextLocation, 2f);
            }
            else
            {
                player.transform.position = nextLocation;
                isMoving = false;
                player.ChangeState(new IdleState());
            }
        }
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }


}
