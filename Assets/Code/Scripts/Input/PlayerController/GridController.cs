using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    Vector3 startLocation;
    int[,] gridLocations = new int[100, 100];
    [SerializeField]
    float tileWidth = 1f, tileHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CanMove(Vector2Int nextPosition)
    {
        if (nextPosition.x <= gridLocations.GetLength(0) && nextPosition.y <= gridLocations.GetLength(1) && nextPosition.x >= 0 && nextPosition.y >= 0)
        {
            return true;
        }
        else
            return false;
    }
    public Vector3 GetGridLocation(Vector2Int gridPosition)
    {
        return startLocation + new Vector3(gridPosition.x * tileWidth,0f, gridPosition.y * tileHeight);
    }
}
