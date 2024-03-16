using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GridController : Singleton<GridController>
{
    [SerializeField]
    Vector3 startLocation;
    public BaseObject[] objectPrefabs;

    private LevelData levelData;


    public TextAsset[] levels;

    //int[,] gridLocations = new int[10, 10];
    [SerializeField]
    float tileWidth = 1f, tileHeight = 1f;



    public int[,] gridLocations = new int[,] { };
    public BaseObject[,] objLocations;

    // Start is called before the first frame update
    void Awake()
    {
        LoadLevel();
        gridLocations = levelData.grid;
        int gridSizeX = gridLocations.GetLength(0);
        int gridSizeY = gridLocations.GetLength(1);
        objLocations = new BaseObject[gridSizeX, gridSizeY];

        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                int gridValue = gridLocations[i, j];
                BaseObject objectClone = Instantiate(objectPrefabs[gridValue]);
                objectClone.transform.localPosition = new Vector3(i, 0, j);
                objectClone.posInGrid = new Vector2Int(i, j);
                objLocations[i, j] = objectClone;
                if(gridValue == 3)
                {
                    objectClone.GetComponent<PlayerController>().gridLocation = new Vector2Int((int)objectClone.transform.position.x, (int)objectClone.transform.position.z);
                    gridLocations[i, j] = 0;
                    gridValue = gridLocations[i, j];
                    BaseObject floorClone = Instantiate(objectPrefabs[gridValue]);
                    floorClone.transform.localPosition = new Vector3(i, 0, j);
                    floorClone.posInGrid = new Vector2Int(i, j);
                    objLocations[i, j] = floorClone;

                }
            }
        }
    }

    private void LoadLevel()
    {
        string myDataString = levels[Random.Range(0, levels.Length)].text;
        levelData = JsonConvert.DeserializeObject<LevelData>(myDataString);

    }

    //0 = floor, 1 = wall, 2 = interact
    public bool CanMove(Vector2Int nextPosition)
    {
        Debug.Log(nextPosition);
        if (CheckMapBoundary(nextPosition) && gridLocations[nextPosition.x, nextPosition.y] == 0)
        {
            return true;
        }
        else
            return false;
    }
    public bool CanAttack(Vector2Int fwdPosition)
    {
        //Check if character in front of player can be attacked


        return true;
    }

    public bool CanInteract(Vector2Int fwdPosition)
    {
        //Check if the object in front of us can be interected with

        if (CheckMapBoundary(fwdPosition) && objLocations[fwdPosition.x, fwdPosition.y].gameObject.GetComponent<InteractableObj>())
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

    private bool CheckMapBoundary(Vector2Int gridPosition)
    {
        return gridPosition.x <= gridLocations.GetLength(0) && gridPosition.y <= gridLocations.GetLength(1) && gridPosition.x >= 0 && gridPosition.y >= 0;
    }
}
