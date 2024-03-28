using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GridController : Singleton<GridController>
{
    [SerializeField]
    Vector3 startLocation;
    public BaseObject[] objectPrefabs;

    private int playerCount = 0;

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
    public List<InteractableObj> interactableObjs = new();
    [HideInInspector]
    public List<AIController> AIList = new();

    public List<GameObject> CharacterModels = new();

    private List<PlayerController> playerControllers = new();


    // Start is called before the first frame update
    void Awake()
    {
        LoadLevel();
        gridLocations = levelData.grid;
        gridRotations = levelData.directions;

        int gridSizeX = gridLocations.GetLength(0);
        int gridSizeY = gridLocations.GetLength(1);
        objLocationsStart = new BaseObject[gridSizeX, gridSizeY];

        playerCount = 0;

        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                int gridValue = gridLocations[i, j];
                char gridRotation = gridRotations[i, j];

                BaseObject objectClone = Instantiate(objectPrefabs[gridValue]);

                objectClone.transform.localPosition = new Vector3(i, 0, j);
                objectClone.posInGrid = new Vector2Int(i, j);
                if (gridRotation.ToString() != "" && (objectClone.GetComponent<InteractableObj>() || objectClone.GetComponent<Wall>()))
                {
                    RotateObject(objectClone, gridRotation);
                }
                else if (objectClone.GetComponent<InteractableObj>())
                {
                    Debug.Log(objectClone.GetComponent<InteractableObj>().interactionPos);
                }

                objLocationsStart[i, j] = objectClone;

                if (objectClone.GetComponent<CharacterClass>())
                {
                    objectClone.GetComponent<CharacterClass>().gridLocation = new Vector2Int((int)objectClone.transform.position.x, (int)objectClone.transform.position.z);
                    objectClone.GetComponent<CharacterClass>().characterModel = Instantiate(CharacterModels[Random.Range(0, CharacterModels.Count)], objectClone.transform);

                    objectClone.GetComponent<CharacterClass>().characterModel.transform.localPosition = new Vector3(0, 1.5f, 0);
                    objectClone.GetComponent<CharacterClass>().characterModel.transform.localRotation = Quaternion.Euler(0, 180f, 0);
                    
                    if (objectClone.GetComponent<PlayerController>())
                    {
                        playerControllers.Add(objectClone.GetComponent<PlayerController>());

                        objectClone.GetComponent<PlayerController>().controlScheme = "P" + playerCount;
                        UIManager uIManager = objectClone.GetComponentInChildren<UIManager>();
                        uIManager.playerUI.transform.rotation = Quaternion.Euler(0, 0, 0);
                        uIManager.playerUI.transform.SetParent(GameManager.Instance.spawnPoints[playerCount]);
                        RectTransform rect = uIManager.playerUI.GetComponent<RectTransform>();
                        rect.anchoredPosition = new Vector2(0, 0);
                        rect.anchorMin = new Vector2(0.5f, 0.5f);
                        rect.anchorMax = new Vector2(0.5f, 0.5f);
                        rect.pivot = new Vector2(0.5f, 0.5f);
                        rect.sizeDelta = new Vector2(0, 0);
                        //position = new Vector3(0, 0, 0);// = Quaternion.Euler(0, 0, 0);


                        Debug.Log("Player " + playerCount + " spawned at " + GameManager.Instance.spawnPoints[playerCount].position);
                        playerCount++;

                    }
                }

                if (objectClone.GetComponent<InteractableObj>())
                {
                    if (objectClone.GetComponent<InteractableObj>().taskType != TaskType.ExtinguishBody)
                    {
                        interactableObjs.Add(objectClone.GetComponent<InteractableObj>());
                    }
                }

                if (objectClone.GetComponent<AIController>())
                {
                    AIList.Add(objectClone.GetComponent<AIController>());
                }
            }
        }

        GameManager.Instance.RankPlayers(playerControllers);

        objLocations = objLocationsStart;

    }

    public int[,] GetGridData()
    {
        return gridLocations;
    }

    private void LoadLevel()
    {
        string myDataString = levels[UnityEngine.Random.Range(0, levels.Length)].text;
        levelData = JsonConvert.DeserializeObject<LevelData>(myDataString);

    }

    //0 = floor, 1 = wall, 2 = interact
    public bool CanMove(Vector2Int nextPosition)
    {
        if (CheckMapBoundary(nextPosition) && gridLocations[nextPosition.x, nextPosition.y] == 0)
        {
            return true;
        }
        else
            return false;
    }

    public bool CanInteract(Vector2Int fwdPosition, TaskManager task)
    {
        //Check if the object in front of us can be interected with

        if (CheckMapBoundary(fwdPosition) && objLocations[fwdPosition.x, fwdPosition.y].gameObject.GetComponent<InteractableObj>())
        {
            if (task.taskToDo.Contains(objLocations[fwdPosition.x, fwdPosition.y].gameObject.GetComponent<InteractableObj>().taskType))
                return true;
            else
                return false;
        }
        else
            return false;

    }

    public bool CanAttack(Vector2Int fwdPosition, Vector2Int playerFwdDirection)
    {
        //Check if the object in front of us can be interected with

        if (CheckMapBoundary(fwdPosition) && objLocations[fwdPosition.x, fwdPosition.y].gameObject.GetComponent<CharacterClass>())
        {
            if (objLocations[fwdPosition.x, fwdPosition.y].gameObject.GetComponent<CharacterClass>().fwdDirection == playerFwdDirection && objLocations[fwdPosition.x, fwdPosition.y].gameObject.GetComponent<CharacterClass>().currentState is IdleState)
                return true;
            else
                return false;
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
                if (instantiatedObj.GetComponent<InteractableObj>())
                {
                    instantiatedObj.GetComponent<InteractableObj>().interactionPos = new Vector2Int(1, 0) + instantiatedObj.posInGrid;
                }
                break;
            case 'L':
                instantiatedObj.transform.eulerAngles = new Vector3(0, 270f, 0);
                if (instantiatedObj.GetComponent<InteractableObj>())
                {
                    instantiatedObj.GetComponent<InteractableObj>().interactionPos = new Vector2Int(-1, 0) + instantiatedObj.posInGrid;
                }
                break;
            case 'U':
                instantiatedObj.transform.eulerAngles = new Vector3(0, 0f, 0);
                if (instantiatedObj.GetComponent<InteractableObj>())
                {
                    instantiatedObj.GetComponent<InteractableObj>().interactionPos = new Vector2Int(0, 1) + instantiatedObj.posInGrid;
                }
                break;
            case 'D':
                instantiatedObj.transform.eulerAngles = new Vector3(0, 180f, 1);
                if (instantiatedObj.GetComponent<InteractableObj>())
                {
                    instantiatedObj.GetComponent<InteractableObj>().interactionPos = new Vector2Int(0, -1) + instantiatedObj.posInGrid;
                }
                break;
            default:
                if (instantiatedObj.GetComponent<InteractableObj>())
                {
                    instantiatedObj.GetComponent<InteractableObj>().interactionPos = new Vector2Int(0, 1) + instantiatedObj.posInGrid;
                }
                break;
        }

    }

}
