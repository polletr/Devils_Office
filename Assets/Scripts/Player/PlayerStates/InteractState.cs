using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class InteractState : BaseState
{
    private float interactTimer;
    private InteractableObj interactableObj;
    private float timer;

    private bool completedTask;

    private PlayerController playerController;

    public override void EnterState()
    {
        character.anim?.SetBool("Interact", true);
        //Enable UI

        if (character.GetComponent<PlayerController>())
        {
            playerController = character.GetComponent<PlayerController>();
        }

        interactableObj = GridController.Instance.objLocations[character.gridLocation.x + character.fwdDirection.x, character.gridLocation.y + character.fwdDirection.y].GetComponent<InteractableObj>();
        

        if (interactableObj.GetComponent<ExtinguishBody>() && interactableObj.GetComponent<AIController>().currentState is not DeathState)
        {
            character.ChangeState(new IdleState());
        }
        else
        {
            if (playerController)
            {
                interactTimer = interactableObj.waitTime * playerController.interactMultiplier;
            }
            else
            {
                interactTimer = interactableObj.waitTime;
            }


            interactableObj.TaskStarted.Invoke();
        }


        timer = 0f;

    }

    public override void ExitState()
    {
        character.anim?.SetBool("Interact", false);

        if (completedTask)
        {
            playerController.points += GameManager.Instance.taskPoints;
            completedTask = false;
        }

        if (character.GetComponent<PlayerController>())
        {

            UIManager uiManager = playerController._UIManager;
            uiManager.showLoader = false;

        }

    }


    public override void StateUpdate()
    {
        timer += Time.deltaTime;
        if(playerController)
        {
            UIManager uiManager = playerController._UIManager;
            uiManager.showLoader = true;
            uiManager.LoadingBar(timer, interactTimer);
        }

        if (timer > interactTimer)
        {

            if (playerController)
            {
                playerController._taskManager.CompleteTask(interactableObj);
                playerController._UIManager.showLoader = false;
                if (interactableObj.GetComponent<ExtinguishBody>())
                {
                    playerController.canInteract = true;
                    Vector2Int objLocation = interactableObj.GetComponent<AIController>().gridLocation;

                    GridController.Instance.objLocations[objLocation.x, objLocation.y] = GridController.Instance.objLocationsStart[objLocation.x, objLocation.y];
                    GridController.Instance.gridLocations[objLocation.x, objLocation.y] = 0;

                }
                else
                {
                    completedTask = true;
                }

            }

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

    public override void HandleDeath()
    {
        Debug.Log("Call Death");
        character.ChangeState(new DeathState());
    }


}
