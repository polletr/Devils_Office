using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : BaseState
{
    private CharacterClass targetCharacter;

    private PlayerController playerController;


    public override void EnterState()
    {

        if (character.GetComponent<PlayerController>())
        {
            playerController = character.GetComponent<PlayerController>();
        }


        character.anim?.SetTrigger("Attack");
        targetCharacter = GridController.Instance.objLocations[character.gridLocation.x + character.fwdDirection.x, character.gridLocation.y + character.fwdDirection.y].GetComponent<CharacterClass>();

        targetCharacter.currentState?.HandleDeath();

        if (playerController.canInteract)
        {
            if (targetCharacter.GetComponent<AIController>())
            {
                playerController._taskManager.AddExtinguishTask();
                playerController.canInteract = false;
            }
            else if (targetCharacter.GetComponent<PlayerController>())
            {
                playerController.points += GameManager.Instance.killPoints;
                playerController.killCount += 1;
            }
        }

        character.ChangeState(new IdleState());
    }

}
