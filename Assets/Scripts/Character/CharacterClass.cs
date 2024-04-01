using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : BaseObject
{
    public float moveSpeed = 1f;
    public float rotateSpeed = 1f;


    [HideInInspector]
    public Vector2Int fwdDirection;
    [HideInInspector]
    public Vector2Int gridLocation;

    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public BaseState currentState;
    [HideInInspector]
    public GameObject characterModel;

    public virtual void Awake()
    {

        transform.eulerAngles = new Vector3(0f, UnityEngine.Random.Range(0,3) * 90f, 0f);
        ChangeDirection();
    }

    public void ChangeState(BaseState newState)
    {
        StartCoroutine(WaitFixedFrame(newState));
    }

    private IEnumerator WaitFixedFrame(BaseState newState)
    {

        yield return new WaitForFixedUpdate();
        currentState?.ExitState();
        currentState = newState;
        currentState.character = this;
        currentState.EnterState();

    }

    void ChangeDirection()
    {
        int directionAngle = (int)Math.Round(transform.eulerAngles.y);
        switch (directionAngle)
        {
            case 0:
                fwdDirection = new Vector2Int(0, 1);
                break;
            case 270:
                fwdDirection = new Vector2Int(-1, 0);
                break;
            case 90:
                fwdDirection = new Vector2Int(1, 0);
                break;
            case 180:
                fwdDirection = new Vector2Int(0, -1);
                break;
        }
    }

}
