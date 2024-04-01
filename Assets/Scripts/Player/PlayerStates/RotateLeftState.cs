using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RotateLeftState : BaseState
{    
    public override void EnterState()
    {
        //Play Animation

        float currentDirection = character.transform.eulerAngles.y;
        nextDirection = currentDirection - 90;
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
        if (character.transform.eulerAngles != new Vector3(0, nextDirection, 0))
        {
            float step = character.rotateSpeed * Time.fixedDeltaTime;
            character.transform.rotation = Quaternion.RotateTowards(character.transform.rotation, Quaternion.Euler(new Vector3(0, nextDirection, 0)), step);
        }
        else
        {
            character.transform.eulerAngles = new Vector3(0, nextDirection, 0);
            ChangeDirection();

            character.ChangeState(new IdleState());
        }

    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    void ChangeDirection()
    {
        int directionAngle = (int)Math.Round(character.transform.eulerAngles.y);
        switch (directionAngle)
        {
            case 0:
                character.fwdDirection = new Vector2Int(0, 1);
                break;
            case 270:
                character.fwdDirection = new Vector2Int(-1, 0);
                break;
            case 90:
                character.fwdDirection = new Vector2Int(1, 0);
                break;
            case 180:
                character.fwdDirection = new Vector2Int(0, -1);
                break;
        }
    }

}
