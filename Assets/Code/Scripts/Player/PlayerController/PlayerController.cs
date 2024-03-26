using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.UIElements;

[RequireComponent(typeof(InputManager))]
public class PlayerController : CharacterClass
{

    public string controlScheme;
    public TaskManager _taskManager;

    public int points;

    public int killCount;

    [HideInInspector]
    public bool canInteract;

    public override void Awake()
    {
        base.Awake();
        _taskManager = GetComponent<TaskManager>();
        ChangeState(new IdleState());
        canInteract = true;

    }
    private void Update()
    {
        currentState?.StateUpdate();

    }
    private void FixedUpdate()
    {
        currentState?.StateFixedUpdate();
    }

    #region character Actions
    public void HandleMove()
    {
        currentState?.HandleMovement();
    }

    public void HandleRotate(float rotateAngle)
    {
        currentState?.HandleRotation(rotateAngle);
    }
    public void HandleInteract()
    {
        currentState?.HandleInteract();
    }

    public void HandleStopInteract()
    {
        currentState?.StopInteract();
    }

    public void HandleViewTask()
    {
        //Define if we want the player to move or not
    }


    #endregion

    public void DestroyModel()
    {
        Destroy(characterModel);
    }

    public void SpawnNewModel(GameObject newModel)
    {
        characterModel = Instantiate(newModel, transform);
    }

}
