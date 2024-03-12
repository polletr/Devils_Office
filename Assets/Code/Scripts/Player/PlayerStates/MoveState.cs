using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveState : BaseState
{
    private bool isMoving;
    private Vector2Int moveDirection;

    private float transitionTimer;

    public override void EnterState()
    {
        //Play Animation
        moveDirection = new Vector2Int(0,1);
        isMoving = true;
        transitionTimer = 0f;
    }

    public override void ExitState()
    {
        base.ExitState();
    }


    public override void StateFixedUpdate()
    {
        Debug.Log("Move");
        Debug.Log(GridController.Instance.CanMove(player.gridLocation));

        if (GridController.Instance.CanMove(player.gridLocation + moveDirection) && isMoving)
        {
            Vector3 currentLocation = player.transform.position;
            player.gridLocation += moveDirection;
            Vector3 nextLocation = GridController.Instance.GetGridLocation(player.gridLocation);

            Debug.Log(nextLocation);

            float t = Mathf.Clamp01(transitionTimer / player.moveDuration);
            transitionTimer += Time.fixedDeltaTime;

            if (t < 1.0f)
            {

                Vector3 newPos = Vector3.Lerp(currentLocation, nextLocation, t);

                player.transform.position = newPos;

            }
            else
            {
                player.transform.position = nextLocation;
                isMoving = false;
                player.ChangeState(new IdleState());
            }
        }
        else
        {
            isMoving = false;
            player.ChangeState(new IdleState());
        }
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }


}
