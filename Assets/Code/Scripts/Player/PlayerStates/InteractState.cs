using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractState : BaseState
{
    private float interactTimer;
    private InteractableObj interactableObj;
    private float timer;
    public override void EnterState()
    {
        //Play Animation
        //Enable UI

        interactableObj = GridController.Instance.objLocations[character.gridLocation.x + character.fwdDirection.x, character.gridLocation.y + character.fwdDirection.y].GetComponent<InteractableObj>();
        interactTimer = interactableObj.waitTime;

        interactableObj.TaskStarted.Invoke();

        timer = 0f;

    }

    public override void StateUpdate()
    {
        timer += Time.deltaTime;
        if (timer > interactTimer)
        {

            character.GetComponent<PlayerController>()?._taskManager.CompleteTask(interactableObj);
            interactableObj.TaskCompleted.Invoke();

            //Disable UI
            character.ChangeState(new IdleState());
        }
    }

    public override void StopInteract()
    {
        //Disable UI
        interactableObj.TaskInterrupted.Invoke();

        character.ChangeState(new IdleState());

    }

}
