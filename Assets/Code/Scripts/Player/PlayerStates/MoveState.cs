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

        if (GridController.Instance.CanMove(character.gridLocation + character.fwdDirection))
        {
            oldLocation = character.gridLocation;
            character.gridLocation += character.fwdDirection;
            nextLocation = GridController.Instance.GetGridLocation(character.gridLocation);

            GridController.Instance.objLocations[oldLocation.x, oldLocation.y] = GridController.Instance.objLocationsStart[oldLocation.x, oldLocation.y];
            GridController.Instance.gridLocations[oldLocation.x, oldLocation.y] = 0;

            GridController.Instance.objLocations[character.gridLocation.x, character.gridLocation.y] = character;
            GridController.Instance.gridLocations[character.gridLocation.x, character.gridLocation.y] = 3;


            canMove = true;
            //Play Animation


        }
        else
        {
            canMove = false;
            character.ChangeState(new IdleState());
        }

    }

    public override void ExitState()
    {

        base.ExitState();
    }


    public override void StateFixedUpdate()
    {
        if (canMove)
        {
            if (Vector3.Distance(character.transform.position, nextLocation) > 0.01f)
            {
                float step = character.moveSpeed * Time.fixedDeltaTime;

                character.transform.position = Vector3.MoveTowards(character.transform.position, nextLocation, step);
            }
            else
            {


                character.transform.position = nextLocation;

                character.ChangeState(new IdleState());
            }

        }
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }


}
