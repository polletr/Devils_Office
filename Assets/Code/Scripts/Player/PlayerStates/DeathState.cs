using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathState : BaseState
{
    private float respawnTimer;
    private float respawnTimerLimit = 5f;
    public override void EnterState()
    {
        //Debug.Log("DeathState");
        //Play Animation


    }

    public override void StateUpdate()
    {
        respawnTimer += Time.deltaTime;
        if (character.GetComponent<PlayerController>())
        {
            if (respawnTimer > respawnTimerLimit)
            {
                //Respawn
                AIController AIPicked =  GridController.Instance.AIList[Random.Range(0, GridController.Instance.AIList.Count)].GetComponent<AIController>();

                
                if (AIPicked.currentState is IdleState)
                {
                    character.GetComponent<PlayerController>().DestroyModel();

                    character.GetComponent<PlayerController>().SpawnNewModel(AIPicked.characterModel);

                    Vector2Int oldLocation = character.gridLocation;

                    GridController.Instance.objLocations[oldLocation.x, oldLocation.y] = GridController.Instance.objLocationsStart[oldLocation.x, oldLocation.y];
                    GridController.Instance.gridLocations[oldLocation.x, oldLocation.y] = 0;

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
            //Clear the current Task List
            //Add Extinguish Body task to tasks
        }



    }

}
