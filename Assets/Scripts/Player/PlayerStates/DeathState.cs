using System.Linq;
using UnityEngine;

public class DeathState : BaseState
{
    private float respawnTimer;

    private PlayerController playerController;

    public override void EnterState()
    {
       
        character.anim.SetBool("Dead", true);
        if (character.GetComponent<PlayerController>())
        {
            playerController = character.GetComponent<PlayerController>();
            playerController._UIManager.StartCoroutine("Blink", true);

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
            AudioManager.Instance.Play(AudioManager.Instance._audioClip.deathIsJustTheBeggining, character.characterSpeaker);
            if (GridController.Instance.AIList.Any())
            {
                if (respawnTimer > playerController.RespawnTimelimit)
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
                        character.GetComponent<PlayerController>()._UIManager.StartCoroutine("Blink", false);

                        character.ChangeState(new IdleState());

                    }

                }

            }
            else
            {
                GridController.Instance.playerControllers.Remove(playerController);
                character.ChangeState(new PermaDeathState());

                Debug.Log(GridController.Instance.playerControllers.Count);
            }

        }
        else
        {
            AudioManager.Instance.Play(AudioManager.Instance._audioClip.someoneHasDies,character.characterSpeaker);
        }




    }

    public override void StopInteract()
    {

    }


}
