using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : BaseState
{
    private CharacterClass targetCharacter;

    private PlayerController playerController;

    private float timer;

    bool targetKilled;
    private bool killWinner = false;


    public override void EnterState()
    {

        if (character.GetComponent<PlayerController>())
        {
            playerController = character.GetComponent<PlayerController>();
        }

        killWinner = false;

        character.anim?.SetTrigger("Attack");
        targetCharacter = GridController.Instance.objLocations[character.gridLocation.x + character.fwdDirection.x, character.gridLocation.y + character.fwdDirection.y].GetComponent<CharacterClass>();

        if (targetCharacter.currentState is IdleState || targetCharacter.currentState is InteractState)
        {
            targetCharacter.currentState?.HandleDeath();
            AudioManager.Instance.Play(AudioManager.Instance._audioClip.stab, character.characterSpeaker);
            //targetKilled = true;

            if (targetCharacter.GetComponent<AIController>())
            {
                AudioManager.Instance.Play(AudioManager.Instance._audioClip.Horriblejob, character.characterSpeaker);
                playerController._taskManager.AddExtinguishTask(targetCharacter.GetComponent<InteractableObj>());
                playerController.canInteract = false;
                //targetKilled = false;
            }
            else if (targetCharacter.GetComponent<PlayerController>())
            {
                if (GridController.Instance.AIList.Any() || GridController.Instance.playerControllers.Count > 2)
                {
                    playerController.points += GameManager.Instance.killPoints;
                    playerController.killCount += 1;
                    //targetKilled = false;
                }
                else
                {
                    killWinner = true;
                }
            }

        }


    }

    public override void ExitState()
    {
        timer = 0f;

        if (killWinner)
        {
            Debug.Log("WinnerCalled");
            GameManager.Instance.SetWinner(playerController);
        }

    }


    public override void StateUpdate()
    {

        
        if (playerController.canInteract && targetCharacter.currentState is DeathState)
        {
            if (targetKilled)
            {


            }

        }

        timer += Time.deltaTime;
        float clipLength = character.anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        if (timer >= clipLength)
        {
            timer = 0f;
            character.ChangeState(new IdleState());
        }

    }

    public override void StopInteract()
    {

    }



}
