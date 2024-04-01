using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DeathState : BaseState
{
    private float respawnTimer;
    private float respawnTimerLimit = 5f;

    private PlayerController playerController;

    public override void EnterState()
    {
        character.anim.SetBool("Dead", true);
        if (character.GetComponent<PlayerController>())
        {
            playerController = character.GetComponent<PlayerController>();
        }

    }

    public override void ExitState()
    {
        character.anim.SetBool("Dead", false);

    }


    public override void StateUpdate()
    {
        respawnTimer += Time.deltaTime;
        if (playerController)
        {
            if (GridController.Instance.AIList.Any())
            {
                if (respawnTimer > respawnTimerLimit)
                {
                    //Respawn
                    AIController AIPicked = GridController.Instance.AIList[Random.Range(0, GridController.Instance.AIList.Count)]?.GetComponent<AIController>();

                    if (AIPicked.currentState is IdleState)
                    {
                        playerController.DestroyModel();

                        playerController.SpawnNewModel(AIPicked.characterModel);

                        Vector2Int oldLocation = character.gridLocation;
                        Vector2Int newLocation = AIPicked.gridLocation;


                        GridController.Instance.objLocations[oldLocation.x, oldLocation.y] = GridController.Instance.objLocationsStart[oldLocation.x, oldLocation.y];
                        GridController.Instance.gridLocations[oldLocation.x, oldLocation.y] = 0;

                        GridController.Instance.objLocations[newLocation.x, newLocation.y] = character;


                        character.transform.position = AIPicked.transform.position;
                        character.gridLocation = AIPicked.gridLocation;
                        character.posInGrid = AIPicked.posInGrid;

                        character.transform.rotation = AIPicked.transform.rotation;
                        character.fwdDirection = AIPicked.fwdDirection;

                        AIPicked.DestroySelf();

                        character.ChangeState(new IdleState());

                    }

                }

            }
            else
            {
                GridController.Instance.playerControllers.Remove(playerController);
                character.ChangeState(new PermaDeathState());
                character.GetComponent<PlayerController>()._UIManager.StartCoroutine("Blink", true);

                Debug.Log(GridController.Instance.playerControllers.Count);
            }

        }
        



    }

    public override void StopInteract()
    {

    }


}
