using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    public char[,] gridRotations = new char[,] { };


    public BaseObject[,] objLocations;     //all objects in the grid at all times
    public BaseObject[,] objLocationsStart;//all objects in the grid that dont move
    [HideInInspector]
    public List <BaseObject> interactableObjs = new();


    // Start is called before the first frame update
    void Awake()
    {
        LoadLevel();
        gridLocations = levelData.grid;
        gridRotations = levelData.directions;

        int gridSizeX = gridLocations.GetLength(0);
        int gridSizeY = gridLocations.GetLength(1);
        objLocationsStart = new BaseObject[gridSizeX, gridSizeY];

        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                int gridValue = gridLocations[i, j];
                char gridRotation = gridRotations[i, j];

                Debug.Log(gridRotation);
                BaseObject objectClone = Instantiate(objectPrefabs[gridValue]);
                if (gridRotation.ToString() != "")
                {
                    RotateObject(objectClone, gridRotation);
                }
                objectClone.transform.localPosition = new Vector3(i, 0, j);
                objectClone.posInGrid = new Vector2Int(i, j);
                objLocationsStart[i, j] = objectClone;

                if (objectClone.GetComponent<CharacterClass>())
                {
                    objectClone.GetComponent<CharacterClass>().gridLocation = new Vector2Int((int)objectClone.transform.position.x, (int)objectClone.transform.position.z);
                }

                if(objectClone.GetComponent<InteractableObj>())
                {
                    interactableObjs.Add(objectClone);
                    Debug.Log(interactableObjs.Count);
                }
            }
        }



        objLocations = objLocationsStart;

        PathFinder.Instance.SetGrid(gridLocations);

    }

    private void LoadLevel()
    {
        string myDataString = levels[UnityEngine.Random.Range(0, levels.Length)].text;
        levelData = JsonConvert.DeserializeObject<LevelData>(myDataString);

    }

    //0 = floor, 1 = wall, 2 = interact
    public bool CanMove(Vector2Int nextPosition)
    {
        if (CheckMapBoundary(nextPosition) && gridLocations[nextPosition.x, nextPosition.y] == 0 )
        {
            return true;
        }
        else
            return false;
    }
    public bool CanAttack(Vector2Int fwdPosition)
    {
        //Check if character in front of character can be attacked


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
        return startLocation + new Vector3(gridPosition.x * tileWidth, 0f, gridPosition.y * tileHeight);
    }

    private bool CheckMapBoundary(Vector2Int gridPosition)
    {
        return gridPosition.x <= gridLocations.GetLength(0) && gridPosition.y <= gridLocations.GetLength(1) && gridPosition.x >= 0 && gridPosition.y >= 0;
    }

    void RotateObject(BaseObject instantiatedObj, char characterRotation)
    {
        switch (characterRotation)
        {
            case 'R':
                instantiatedObj.transform.eulerAngles = new Vector3(0, 90f, 0);
                break;
            case 'L':
                instantiatedObj.transform.eulerAngles = new Vector3(0, 270f, 0);
                break;
            case 'U':
                instantiatedObj.transform.eulerAngles = new Vector3(0, 0f, 0);
                break;
            case 'D':
                instantiatedObj.transform.eulerAngles = new Vector3(0, 180f, 1);
                break;
        }
    }

}
