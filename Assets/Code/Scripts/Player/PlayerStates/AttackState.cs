using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : BaseState
{
    private CharacterClass targetCharacter;

    public override void EnterState()
    {
        //Play Animation
        targetCharacter = GridController.Instance.objLocations[character.gridLocation.x + character.fwdDirection.x, character.gridLocation.y + character.fwdDirection.y].GetComponent<CharacterClass>();

        targetCharacter.currentState?.HandleDeath();

        if (targetCharacter.GetComponent<AIController>())
        {
            character.GetComponent<PlayerController>()?._taskManager.AddExtinguishTask();
        }
        else if (targetCharacter.GetComponent<PlayerController>())
        {
            character.GetComponent<PlayerController>().points += GameManager.Instance.killPoints;
            character.GetComponent<PlayerController>().killCount += 1;
        }

        character.ChangeState(new IdleState());
    }

}
