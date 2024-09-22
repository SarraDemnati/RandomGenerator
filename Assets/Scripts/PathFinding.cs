using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    Grid grid;
    public Transform startPosition;
    public Transform targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<Grid>();
        FindPath(startPosition.position, targetPosition.position);
    }

    // Update is called once per frame
    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
    }
}
