using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    private GameObject[,] mapLocations = new GameObject[,] { };
    [SerializeField] GameObject groundSprite;
    [SerializeField] GameObject miniMapSpawn;

    [SerializeField] Color wallColor;
    [SerializeField] Color playerColor;
    [SerializeField] Color taskColor;
    [SerializeField] Color blankColor;


    List<Vector2Int> trashList = new List<Vector2Int>();
    Vector2Int playerLocation;
    private void Awake()
    {
        GridController.Instance.GridAwakeEvent += InitializeMap;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitializeMap()
    {
        float xWidth = 500f;
        float yWidth = 500f;

        int[,] gridLocations = GridController.Instance.gridLocations;
        float yInc = 10f;// (float)gridLocations.GetLength(0) / yWidth;
        float xInc = 10f;//   (float)gridLocations.GetLength(1) / xWidth;
        mapLocations = new GameObject[gridLocations.GetLength(0), gridLocations.GetLength(1)];
        for (int i = 0; i < gridLocations.GetLength(0); i++)
        {
            for (int j = 0; j < gridLocations.GetLength(1); j++)
            {
                if (gridLocations[i, j] != 0 && gridLocations[i, j] != 4 && gridLocations[i, j] != 5)
                {
                    mapLocations[i, j] = Instantiate(groundSprite, miniMapSpawn.transform);
                    mapLocations[i, j].transform.Translate(new Vector3(i * xInc, -gridLocations.GetLength(1) * yInc + j * yInc, 0f));
                    mapLocations[i,j].GetComponent<Image>().color = wallColor;
                }
                else
                {
                    mapLocations[i, j] = Instantiate(groundSprite, miniMapSpawn.transform);
                    mapLocations[i, j].transform.Translate(new Vector3(i * xInc, -gridLocations.GetLength(1) * yInc + j * yInc, 0f));
                    mapLocations[i, j].GetComponent<Image>().color = blankColor;
                }
            }
        }
    }
    public void ShowMiniMap(PlayerController playerController)
    {
        miniMapSpawn.SetActive(true);
        playerLocation = playerController.gridLocation;
        mapLocations[playerLocation.x, playerLocation.y].GetComponent<Image>().color = playerColor;

        foreach (InteractableObj task in GridController.Instance.interactableObjs)
        {
            if (playerController._taskManager.taskToDo.Contains(task.taskType))
            {
                mapLocations[task.posInGrid.x, task.posInGrid.y].GetComponent<Image>().color = taskColor;
                trashList.Add(new Vector2Int(task.posInGrid.x, task.posInGrid.y));
            }
        }
        //for old player location, make blank color. for new player player location, make player color
        //for old task locations, clear the task locations. set up for new ones
    }

    public void ClearMiniMap()
    {

        mapLocations[playerLocation.x, playerLocation.y].GetComponent<Image>().color = blankColor;

        foreach (Vector2Int tile in trashList)
        {
            mapLocations[tile.x,tile.y].GetComponent<Image>().color = wallColor;
        }

        miniMapSpawn.SetActive(false);

    }

}