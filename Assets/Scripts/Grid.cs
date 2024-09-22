using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public LayerMask unWalkableMask;
    [SerializeField] public Vector2 gridworldSize;
    public Vector2 gridSize;
    public float nodeRadius;

    Node[,] grid;

    float nodeDiameter;

    // Start is called before the first frame update
    void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSize.x = Mathf.RoundToInt(gridworldSize.x /nodeDiameter);
        gridSize.y = Mathf.RoundToInt(gridworldSize.y / nodeDiameter);
        GreateGrid();
    }

    // Update is called once per frame
    void GreateGrid()
    {
        grid = new Node[Mathf.RoundToInt(gridSize.x), Mathf.RoundToInt(gridSize.y)];
        Vector3 worlddBottomLeft = transform.position - Vector3.right * gridworldSize.x/ 2 - Vector3.forward * gridworldSize.y /2;

        for (int x = 0; x< gridSize.x; x++) 
        {
            for (int y = 0; y < gridSize.y; y++) 
            {
                Vector3 worldPoint = worlddBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unWalkableMask));
                grid[x, y] = new Node(worldPoint,walkable);
            }

        }

    }

    public Node NodeFromWorldPoint(Vector3 worldPostion)
    {
        float percentX = (worldPostion.x + gridworldSize.x / 2) / gridworldSize.x;
        float percentY = (worldPostion.z + gridworldSize.y / 2) / gridworldSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSize.x - 1)* percentX);
        int y = Mathf.RoundToInt((gridSize.y - 1)*percentY);

        return grid[x, y];
    }
}
