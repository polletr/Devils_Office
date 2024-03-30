using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class PlayerController : CharacterClass
{
    [HideInInspector]
    public string controlScheme;

    [HideInInspector]
    public TaskManager _taskManager;

    [HideInInspector]
    public UIManager _UIManager;

    [HideInInspector]
    public int points;

    [HideInInspector]
    public int killCount;

    [HideInInspector]
    public bool canInteract;

    [HideInInspector]
    public float interactMultiplier = 1;

    [HideInInspector]
    public float interactTimer;
   


public override void Awake()
    {
        base.Awake();
        _taskManager = GetComponent<TaskManager>();
        _UIManager = GetComponentInChildren<UIManager>();
        Invoke(nameof(GetAnim), 0.5f);   // use catch event instead of invoke

        ChangeState(new IdleState());
        canInteract = true;
        interactMultiplier = 1;

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

    public void HandleViewTask(bool show)
    {
        _UIManager.DisableUI(show);

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
