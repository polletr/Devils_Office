using System;
using System.Collections.Generic;

public class AStar
{
    // Define a simple node structure to represent each cell in the grid
    public class Node
    {
        public int x, y; // Position of the node in the grid
        public bool walkable; // Whether this node is walkable or not
        public float gCost; // Cost to move to this node from the start node
        public float hCost; // Heuristic estimate of the cost to reach the goal from this node
        public float fCost => gCost + hCost; // Total estimated cost of the node (gCost + hCost)
        public Node parent; // Parent node used to reconstruct the path

        public Node(int x, int y, bool walkable)
        {
            this.x = x;
            this.y = y;
            this.walkable = walkable;
        }
    }

    // Function to find the shortest path using A* algorithm
    public static List<Node> FindPath(Node startNode, Node targetNode, Node[,] grid)
    {
        List<Node> openSet = new List<Node>(); // List of nodes to be evaluated
        HashSet<Node> closedSet = new HashSet<Node>(); // Set of nodes already evaluated

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                // Find the node in the open set with the lowest fCost
                if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))//If fCost is the same, choose the one with the lowest hCost
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                // If we reached the target node, reconstruct and return the path
                return RetracePath(startNode, targetNode);
            }

            foreach (Node neighbor in GetNeighbors(currentNode, grid))
            {
                if (!neighbor.walkable || closedSet.Contains(neighbor))
                {
                    continue;
                }

                float newCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);
                if (newCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newCostToNeighbor;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }

        // If no path found, return an empty list
        return new List<Node>();
    }

    // Function to reconstruct the path from the start node to the end node
    private static List<Node> RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse(); // Reverse the path to get it from start to end
        return path;
    }

    // Function to get the neighbors of a node
    private static List<Node> GetNeighbors(Node node, Node[,] grid)
    {
        List<Node> neighbors = new List<Node>();
        int gridSizeX = grid.GetLength(0);
        int gridSizeY = grid.GetLength(1);

        int[] offsetX = { -1, 0, 1, 0 }; // Offsets for left, up, right, down neighbors
        int[] offsetY = { 0, -1, 0, 1 };

        for (int i = 0; i < 4; i++)
        {
            int neighborX = node.x + offsetX[i];
            int neighborY = node.y + offsetY[i];

            if (neighborX >= 0 && neighborX < gridSizeX && neighborY >= 0 && neighborY < gridSizeY)
            {
                neighbors.Add(grid[neighborX, neighborY]);
            }
        }

        return neighbors;
    }

    // Function to calculate the distance between two nodes (heuristic function)
    private static float GetDistance(Node nodeA, Node nodeB)
    {
        int distX = Math.Abs(nodeA.x - nodeB.x);
        int distY = Math.Abs(nodeA.y - nodeB.y);
        return distX + distY; // Manhattan distance for simplicity
    }
}
