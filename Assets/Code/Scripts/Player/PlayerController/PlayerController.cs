using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

[RequireComponent(typeof(InputManager))]
public class PlayerController : CharacterClass
{
    [HideInInspector]
    public string controlScheme;

    [HideInInspector]
    public TaskManager _taskManager;
    private UIManager UIManager;

    [HideInInspector]
    public int points;

    [HideInInspector]
    public int killCount;

    [HideInInspector]
    public bool canInteract;

    public override void Awake()
    {
        base.Awake();
        _taskManager = GetComponent<TaskManager>();
        UIManager = GetComponentInChildren<UIManager>();
        Invoke(nameof(GetAnim), 0.5f);   // use catch event instead of invoke

        ChangeState(new IdleState());
        canInteract = true;

    }
    private void Update()
    {
        currentState?.StateUpdate();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeState(new DeathState());
        }
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

    public void HandleViewTask( bool show)
    {
        UIManager.DisableUI(show);

    }


    #endregion

    public void DestroyModel()
    {
        Destroy(characterModel);
    }

    public void SpawnNewModel(GameObject newModel)
    {

        newModel.transform.SetParent(transform, false);
        anim = newModel.GetComponent<Animator>();
        Debug.Log(anim.ToString());
    }

    public void GetAnim()
    {
        anim = GetComponentInChildren<Animator>();
    }


}
