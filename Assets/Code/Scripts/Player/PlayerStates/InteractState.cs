using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractState : BaseState
{
    private float interactTimer;

    private float timer;
    public override void EnterState()
    {
        //Play Animation
        //Enable UI

        interactTimer = GridController.Instance.objLocations[character.gridLocation.x + character.fwdDirection.x, character.gridLocation.y + character.fwdDirection.y].GetComponent<InteractableObj>().waitTime;
        timer = 0f;

    }

    public override void StateUpdate()
    {
        timer += Time.deltaTime;
        if (timer > interactTimer)
        {
            Debug.Log("Done Coffee");
            //Disable UI
            character.ChangeState(new IdleState());
        }
    }

    public override void StopInteract()
    {
        //Disable UI

        character.ChangeState(new IdleState());
        
    }

}
