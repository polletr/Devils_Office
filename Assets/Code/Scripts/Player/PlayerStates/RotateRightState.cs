using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRightState : BaseState
{    
    public override void EnterState()
    {
        //Play Animation

        float currentDirection = player.transform.eulerAngles.y;
        nextDirection = currentDirection + 90;
        if (nextDirection >= 360)
        {
            nextDirection -= 360;
        }
        else if (nextDirection < 0)
        {
            nextDirection += 360;
        }

    }

    public override void ExitState()
    {
        base.ExitState();
    }


    public override void StateFixedUpdate()
    {
        if (player.transform.eulerAngles != new Vector3(0, nextDirection, 0))
        {
            float step = player.rotateSpeed * Time.fixedDeltaTime;
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.Euler(new Vector3(0, nextDirection, 0)), step);
        }
        else
        {
            player.transform.eulerAngles = new Vector3(0, nextDirection, 0);
            ChangeDirection();

            player.ChangeState(new IdleState());
        }

    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    void ChangeDirection()
    {
        int directionAngle = (int)Math.Round(player.transform.eulerAngles.y);
        switch (directionAngle)
        {
            case 0:
                player.fwdDirection = new Vector2Int(0, 1);
                break;
            case 270:
                player.fwdDirection = new Vector2Int(-1, 0);
                break;
            case 90:
                player.fwdDirection = new Vector2Int(1, 0);
                break;
            case 180:
                player.fwdDirection = new Vector2Int(0, -1);
                break;
        }
    }

}
