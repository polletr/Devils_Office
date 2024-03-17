using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : BaseObject
{
    [HideInInspector]
    public Vector2Int fwdDirection;
    [HideInInspector]
    public Vector2Int gridLocation;


    // Start is called before the first frame update
    protected virtual void Awake()
    {
        transform.eulerAngles = new Vector3(0f, UnityEngine.Random.Range(0,3) * 90f, 0f);
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
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
