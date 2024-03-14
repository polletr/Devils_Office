using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField]
    GridController gridController;
    public Vector2Int fwdDirection;
    [SerializeField]
    Vector2Int gridLocation;
    bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
            return;
        if (Input.GetAxis("Horizontal") < 0)
        {
            isMoving = true;
            StartCoroutine(RotatePlayer(-90));
            
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            isMoving = true;
            StartCoroutine(RotatePlayer(90));

        }
        if (Input.GetAxis("Vertical") > 0 && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MovePlayer());
        }
    }
    IEnumerator RotatePlayer(float rotation)
    {
        float currentDirection = transform.eulerAngles.y;
        float nextDirection = currentDirection + rotation;
        float blendValue = .01f;
        while (blendValue <= 1f)
        {
            transform.eulerAngles = new Vector3(0, (1.0f - blendValue) * currentDirection + blendValue * nextDirection, 0);
            yield return new WaitForFixedUpdate();
            blendValue += Time.fixedDeltaTime;
        }
        transform.eulerAngles =new Vector3(0, nextDirection, 0);
        ChangeDirection();
        isMoving = false;
    }
    IEnumerator MovePlayer()
    {
        if(gridController.CanMove(gridLocation + fwdDirection))
        {
            Vector3 currentLocation = transform.position;
            gridLocation += fwdDirection;
            float blendValue = .01f;
            Vector3 nextLocation = gridController.GetGridLocation(gridLocation);
            
            while (blendValue <= 1f)
            {
                transform.position = (1.0f - blendValue) * currentLocation + blendValue * nextLocation;
                yield return new WaitForFixedUpdate();
                blendValue += Time.fixedDeltaTime;
            }
            transform.position = nextLocation;
        }
        isMoving = false;
    }

    void ChangeDirection()
    {
        int directionAngle = (int)Math.Round(this.transform.eulerAngles.y);
        Debug.LogFormat("Our y angle is {0}", directionAngle);
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
