using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Tile
{
    public bool isWalkable;
    public Vector2Int pos;
    public Tile previousTile;
}
public class PathFinder : MonoBehaviour
{
    // Start is called before the first frame update
    private Tile[,] tiles;
    private Queue<Tile> frontier;
    private List<Tile> surroundingTiles = new List<Tile>();

    Tile nextTile; 
    public void SetGrid(int[,] grid)
    {
        tiles = new Tile[grid.GetLength(0), grid.GetLength(1)];
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                Tile t = new Tile(); ;
                t.pos = new Vector2Int(i, j);
                //Walkable if not a wall

                //0 = floor
                t.isWalkable = grid[i, j] == 0;

                tiles[i, j] = t;
            }
        }
    }

    public void SetGridFromController()
    {
        int[,] gridData = GridController.Instance.GetGridData();
        SetGrid(gridData);
    }


public Stack<Vector2Int> GetPath(Vector2Int startPos, Vector2Int destination)
    {
        foreach (Tile t in tiles)
        {
            t.previousTile = null;
        }

        Stack<Vector2Int> path = new Stack<Vector2Int>();

        Tile startTile = tiles[startPos.x, startPos.y];
        frontier = new Queue<Tile>();

        frontier.Enqueue(startTile);

        while (frontier.Count != 0)
        {

            Tile current = frontier.Dequeue();


            if (current.pos == destination)
            {
                while (current != startTile)
                {
                    Debug.DrawLine(
                    new Vector3(current.pos.x, 0.5f, current.pos.y),
                    new Vector3(current.previousTile.pos.x, 0.5f, current.previousTile.pos.y), Color.red, .2f);

                    path.Push(current.pos);
                    current = current.previousTile;

                }
                return path;
            }

            AddSurroundingTiles(current, destination);
        }

        return path;
    }

    private void AddSurroundingTiles(Tile origin, Vector2Int destination)
    {
        AddTile(origin, 1, 0, destination);
        AddTile(origin, 0, 1, destination);
        AddTile(origin, 0, -1, destination);
        AddTile(origin, -1, 0, destination);
    }

    private void AddTile(Tile origin, int dirX, int dirY, Vector2Int destination)
    {
        int tileX = origin.pos.x + dirX;
        int tileY = origin.pos.y + dirY;

        if (tileX < 0 || tileX >= tiles.GetLength(0) || tileY < 0 || tileY >= tiles.GetLength(1))
            return;

        Tile surrTile = tiles[tileX, tileY];

        if (!surrTile.isWalkable || surrTile.previousTile != null)
            return;

        Debug.DrawLine(
            new Vector3(origin.pos.x, 0.5f, origin.pos.y),
            new Vector3(surrTile.pos.x, 0.5f, surrTile.pos.y), Color.green, .2f);

        surrTile.previousTile = origin;
        frontier.Enqueue(surrTile);
    }
}