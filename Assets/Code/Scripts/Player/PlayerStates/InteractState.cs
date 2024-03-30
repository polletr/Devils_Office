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
    public override void EnterState()
    {
        character.anim?.SetBool("Interact", true);
        //Enable UI

        interactableObj = GridController.Instance.objLocations[character.gridLocation.x + character.fwdDirection.x, character.gridLocation.y + character.fwdDirection.y].GetComponent<InteractableObj>();
        
        if (character.GetComponent<PlayerController>())
        {
            interactTimer = interactableObj.waitTime * character.GetComponent<PlayerController>().interactMultiplier;
        }
        else
        {
            interactTimer = interactableObj.waitTime;
        }


        interactableObj.TaskStarted.Invoke();

        timer = 0f;

    }

    public override void ExitState()
    {
        character.anim?.SetBool("Interact", false);

        if (completedTask)
        {
            character.GetComponent<PlayerController>().points += GameManager.Instance.taskPoints;
            completedTask = false;
        }
    }


    public override void StateUpdate()
    {
        timer += Time.deltaTime;
        if(character.GetComponent<PlayerController>())
        {
            UIManager uiManager = character.GetComponent<PlayerController>()._UIManager;
            uiManager.showLoader = true;
            uiManager.LoadingBar(timer, interactTimer);
        }

        if (timer > interactTimer)
        {

            if (character.GetComponent<PlayerController>())
            {
                character.GetComponent<PlayerController>()._taskManager.CompleteTask(interactableObj);
                character.GetComponent<PlayerController>()._UIManager.showLoader = false;
                if (interactableObj.GetComponent<ExtinguishBody>())
                {
                    character.GetComponent<PlayerController>().canInteract = true;
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


        if (character.GetComponent<PlayerController>())
        {
            Debug.Log("StopInteract");

            UIManager uiManager = character.GetComponent<PlayerController>()._UIManager;
            uiManager.showLoader = false;
            uiManager.UnloadingBar();

        }


        character.ChangeState(new IdleState());

    }

}
